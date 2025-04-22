import requests
import qrcode
import csv
import os
from pathlib import Path

assignment_letter = {
    "judge": "J",
    "runner": "R",
    "scrambler": "S",
    "delegate": "D",
    "dataentry": "DE"
}

competition_id = "SpanishChampionship2024"
wcif_url = f"https://www.worldcubeassociation.org/api/v0/competitions/{competition_id}/wcif/public"
output_dir = "qrs"
os.makedirs(output_dir, exist_ok=True)

try:
    response = requests.get(wcif_url)
    response.raise_for_status()
    wcif = response.json()
    data = [["id", "name", "wcaId", "newcomer", "role", "qr"]]
    event_activity_codes = [event["id"] for event in wcif["events"]]

    for event in event_activity_codes:
        data[0].append(event)
        data[0].append(f"staff-{event}")

    for person in wcif["persons"]:
        if person["registrantId"] is not None:
            link = f"https://www.competitiongroups.com/competitions/{competition_id}/persons/{person["registrantId"]}"
            qr = qrcode.QRCode(
                version=None,
                error_correction=qrcode.constants.ERROR_CORRECT_L,
                box_size=3,
                border=1,
            )
            qr.add_data(link)
            qr.make(fit=True)
            img = qr.make_image(fill_color="black", back_color="white").convert("RGBA")
            qr_data = img.getdata()
            qr_new_data = []

            for item in qr_data:
                if item[:3] == (255, 255, 255):
                    qr_new_data.append((255, 255, 255, 0))
                else:
                    qr_new_data.append(item)

            img.putdata(qr_new_data)
            path = os.path.join(output_dir, f"{person["registrantId"]}.png")
            img.save(path)
            row = [f"ID: {person["registrantId"]}", f"{person["name"]}"]
            female = person["gender"] == "f"

            if person["wcaId"] is not None:
                row.extend([person["wcaId"], ""])
            else:
                row.extend(["NUEVA COMPETIDORA" if female else "NUEVO COMPETIDOR", "RUTA IMAGEN"])

            if "organizer" in person["roles"]:
                if "delegate" in person["roles"]:
                    row.append("DELEGADA Y ORGANIZADORA" if female else "DELEGADO Y ORGANIZADOR")
                else:
                    row.append("ORGANIZADORA" if female else "ORGANIZADOR")
            elif "delegate" in person["roles"]:
                row.append("DELEGADA" if female else "DELEGADO")
            else:
                row.append("COMPETIDORA" if female else "COMPETIDOR")

            row.append(Path.cwd() / path)
            assignments = person["assignments"]

            def flatten_activities(activities):
                result = []
                for activity in activities:
                    result.append(activity)
                    if "childActivities" in activity:
                        result.extend(flatten_activities(activity["childActivities"]))
                return result

            rooms = wcif["schedule"]["venues"][0]["rooms"]
            activities = flatten_activities(sum([room["activities"] for room in rooms], []))

            for event in event_activity_codes:
                flag = False
                staff_assignments = ""
                for activity in activities:
                    if activity["activityCode"].startswith(f"{event}-r1"):
                        for assignment in assignments:
                            if assignment["activityId"] == activity["id"]:
                                if assignment["assignmentCode"] == "competitor":
                                    row.append(activity["activityCode"].split("-")[-1][1:])
                                    flag = True
                                else:   
                                    staff_assignments += f"{assignment_letter[assignment["assignmentCode"][6:]]}{activity["activityCode"].split("-")[-1][1:]}, "
                if not flag:
                    row.append("")
                row.append(staff_assignments[:-2] if staff_assignments else "")

            data.append(row)

    with open("badges.csv", mode="w", newline="", encoding="utf-8-sig") as file:
        writer = csv.writer(file, delimiter=";")
        writer.writerows(data)

except Exception as e:
    print(f'Error: {e}')


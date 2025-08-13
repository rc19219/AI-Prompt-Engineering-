import sys
import json
import csv
import os

def convert_json_to_csv(json_data, csv_file_path):
    if not isinstance(json_data, list):
        raise ValueError("JSON root must be a list of objects.")
    if not json_data:
        raise ValueError("JSON list is empty.")

    keys = json_data[0].keys()
    with open(csv_file_path, 'w', newline='', encoding='utf-8') as csvfile:
        writer = csv.DictWriter(csvfile, fieldnames=keys)
        writer.writeheader()
        for row in json_data:
            writer.writerow(row)

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: python json_to_csv.py input.json [output.csv]")
        sys.exit(1)

    input_path = sys.argv[1]
    output_path = sys.argv[2] if len(sys.argv) > 2 else "output.csv"

    if not os.path.exists(input_path):
        print(f"Input file {input_path} does not exist.")
        sys.exit(1)

    try:
        with open(input_path, 'r', encoding='utf-8') as f:
            data = json.load(f)
    except Exception as e:
        print(f"Error reading or parsing JSON: {e}")
        sys.exit(1)

    try:
        convert_json_to_csv(data, output_path)
        print(f"CSV file has been saved to {output_path}")
    except Exception as e:
        print(f"Error converting to CSV: {e}")
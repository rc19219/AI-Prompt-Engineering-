# This Python script reads fruit data from 'fruits.csv', 
# converts it to JSON format, and writes the result to 'fruits.json'

import csv
import json

# Specify the input CSV file and output JSON file names
csv_file = "fruits.csv"
json_file = "fruits.json"

data = []  # List to hold rows from CSV as dictionaries

# Open the CSV file and read its contents
with open(csv_file, newline='') as f:
    reader = csv.DictReader(f)  # Read rows as dictionaries using header row
    for row in reader:
        data.append(row)  # Add each row dictionary to the data list

# Write the list of dictionaries to a JSON file
with open(json_file, "w") as f:
    json.dump(data, f, indent=2)  # Dump data as formatted JSON

import pandas as pd
import pymongo
from models import Patient


myclient = pymongo.MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false")
mydb = myclient["ens_game"]
patient_report = {}

class Patient_functions:

    def write_on_db(self,report_no, pname,difficulty, time, status):
        report_no = report_no
        pname = pname
        difficulty = difficulty
        time = time
        status = status
        patient = Patient(
                        report_no = report_no,
                        pname = pname,
                        difficulty = difficulty,
                        time = time,
                        status = status,
                    )
        patient_col = mydb['patient']
        patient_col.insert_one(patient.dict())
        pass

    def pull_from_db(self, report_no):
        myquery = {"report_no": f'{report_no}' }
        patient_col = mydb['patient']
        mydoc = patient_col.find(myquery, {'_id': 0})
        for x in mydoc:
            print(x)
        patient_report[report_no] = x
        pass
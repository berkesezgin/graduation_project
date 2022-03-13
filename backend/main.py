from os import posix_spawn
from fastapi import FastAPI
from starlette.middleware.cors import CORSMiddleware
from pydantic import BaseModel
from models import Patient
from fastapi import Path
from fastapi import Query
from fastapi import Body
from fastapi import BackgroundTasks
import ens_game as ens_game
from ens_game import Patient_functions

app = FastAPI()

origins = ["*"]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


class NewPatientInput(BaseModel):
    report_no: str
    pname:str
    difficulty: str
    time:str
    status:str

class NewRequestPatientInput(BaseModel):
    report_no: str

patient_func = Patient_functions()

@app.get("/")
def home():
    return {"message": "ens-game"}

@app.post("/send_patient_data")
async def patient_data(new_patientInput: NewPatientInput, background_tasks: BackgroundTasks):
    background_tasks.add_task(patient_func.write_on_db,new_patientInput.report_no, new_patientInput.pname, new_patientInput.difficulty, new_patientInput.time, new_patientInput.status)
    return {"message": "sent to db"}


@app.get("/patient_report")
async def patient_report(reportInput:str):
    patient_func.pull_from_db(reportInput)
    patient_result = {}
    patient_report = ens_game.patient_report.get(reportInput, " ")
    patient_result["patient_report"] = patient_report
    report_no = patient_result["patient_report"]["report_no"]
    pname = patient_result["patient_report"]["pname"]
    difficulty = patient_result["patient_report"]["difficulty"]
    time = patient_result["patient_report"]["time"]
    status = patient_result["patient_report"]["status"]
    return patient_result["patient_report"]
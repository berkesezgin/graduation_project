from pydantic import BaseModel
from typing import List

class Patient(BaseModel):
    report_no: str
    pname: str
    difficulty: str
    time: str
    status: str
# app/core/repository.py

from typing import List
from app.core.models import RequestModel

requests_db: List[RequestModel] = []

def save_request(request: RequestModel):
    requests_db.append(request)

def get_all_requests() -> List[RequestModel]:
    return requests_db

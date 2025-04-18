import os
from pathlib import Path
from fastapi import APIRouter, Request
from fastapi.templating import Jinja2Templates

from app.storage import request_storage

staff_router = APIRouter()

BASE_DIR = Path(__file__).resolve().parent.parent
templates = Jinja2Templates(directory=os.path.join(BASE_DIR, "templates"))


@staff_router.get("/staff")
def staff_dashboard(request: Request):
    return templates.TemplateResponse("staff_dashboard.html", {"request": request})


@staff_router.get("/staff/requests")
def view_requests(request: Request):
    return templates.TemplateResponse("staff_requests.html", {
        "request": request,
        "all_requests": request_storage  # Показываем все заявки
    })

import os
from pathlib import Path
from fastapi import APIRouter, Request, Form
from fastapi.responses import RedirectResponse, HTMLResponse
from fastapi.templating import Jinja2Templates

from app.storage import request_storage

client_router = APIRouter()

BASE_DIR = Path(__file__).resolve().parent.parent
templates = Jinja2Templates(directory=os.path.join(BASE_DIR, "templates"))


@client_router.get("/request")
def request_form(request: Request):
    return templates.TemplateResponse("request_form.html", {"request": request})


@client_router.post("/request")
def submit_request(
    request: Request,
    full_name: str = Form(...),
    age: int = Form(...),
    category: str = Form(...),
    description: str = Form(...)
):
    username = "test_user"  # Имя пользователя — временно фиксированное
    request_data = {
        "username": username,
        "full_name": full_name,
        "age": age,
        "category": category,
        "description": description
    }
    request_storage.append(request_data)
    print(f"Новая заявка от {full_name}, возраст {age}, категория {category}: {description}")
    return RedirectResponse(url="/client", status_code=303)


@client_router.get("/client", response_class=HTMLResponse)
async def client_dashboard(request: Request):
    username = "test_user"
    user_requests = [r for r in request_storage if r["username"] == username]
    return templates.TemplateResponse("client_dashboard.html", {
        "request": request,
        "user_requests": user_requests
    })

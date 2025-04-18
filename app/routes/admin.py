from fastapi import APIRouter, Request, Form
from fastapi.responses import HTMLResponse, RedirectResponse
from app.core.templates import templates
from app.storage import user_storage

admin_router = APIRouter()


@admin_router.get("/admin", response_class=HTMLResponse)
async def admin_dashboard(request: Request):
    return templates.TemplateResponse("admin_dashboard.html", {
        "request": request,
        "all_users": user_storage
    })


@admin_router.get("/admin/add-staff", response_class=HTMLResponse)
async def add_staff_form(request: Request):
    return templates.TemplateResponse("add_staff.html", {
        "request": request
    })


@admin_router.post("/admin/add-staff")
async def create_staff(
    request: Request,
    username: str = Form(...),
    email: str = Form(...),
    password: str = Form(...),  # В будущем будем хэшировать
    role: str = Form(...)
):
    new_user = {
        "username": username,
        "email": email,
        "password": password,
        "role": role
    }
    user_storage.append(new_user)
    print(f"✅ Добавлен новый пользователь: {username}, роль: {role}")
    return RedirectResponse(url="/admin", status_code=303)

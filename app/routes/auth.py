from fastapi import APIRouter, Request, Form, status
from fastapi.responses import RedirectResponse
from fastapi.templating import Jinja2Templates

auth_router = APIRouter()
templates = Jinja2Templates(directory="app/templates")

# Роут для отображения формы входа
@auth_router.get("/login")
def login_get(request: Request):
    return templates.TemplateResponse("login.html", {"request": request})

# Роут для обработки формы входа
@auth_router.post("/login")
def login_post(email: str = Form(...), password: str = Form(...)):
    # Здесь будет проверка учетных данных через API
    if email == "admin@example.com" and password == "admin":  # временно
        return RedirectResponse("/admin", status_code=status.HTTP_302_FOUND)
    elif email == "staff@example.com":
        return RedirectResponse("/staff", status_code=status.HTTP_302_FOUND)
    else:
        return RedirectResponse("/client", status_code=status.HTTP_302_FOUND)

# Роут для отображения формы регистрации
@auth_router.get("/register")
def register_get(request: Request):
    return templates.TemplateResponse("register.html", {"request": request})

# Роут для обработки формы регистрации
@auth_router.post("/register")
def register_post(name: str = Form(...), email: str = Form(...), password: str = Form(...)):
    # Здесь отправка данных на сервер через API
    print(f"Зарегистрирован: {name}, {email}")
    return RedirectResponse("/login", status_code=status.HTTP_302_FOUND)

import logging
logging.basicConfig(level=logging.DEBUG)

from fastapi import FastAPI
from fastapi.staticfiles import StaticFiles
from app.core.templates import templates

# Импорт роутеров
from app.routes.auth import auth_router
from app.routes.client import client_router
from app.routes.staff import staff_router
from app.routes.admin import admin_router

app = FastAPI()

# Подключаем статические файлы и шаблоны
app.mount("/static", StaticFiles(directory="app/static"), name="static")

# Подключаем роутеры
app.include_router(auth_router)
app.include_router(client_router)
app.include_router(staff_router)
app.include_router(admin_router)

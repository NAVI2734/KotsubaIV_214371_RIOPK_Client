# app/core/models.py

from pydantic import BaseModel, EmailStr
from typing import Optional

class RequestModel(BaseModel):
    full_name: str                   # ФИО
    age: int                         # Возраст
    phone: Optional[str] = None      # Телефон
    email: Optional[EmailStr] = None # Email
    address: Optional[str] = None    # Адрес проживания
    social_status: Optional[str] = None  # Социальный статус (пенсионер, инвалид и т.д.)
    description: str                # Описание ситуации
    urgent: bool = False            # Требуется срочная помощь

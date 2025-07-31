# Advertising Platforms API

REST API для управления рекламными площадками и загрузки данных из файла.

## 📦 Технологии

- ASP.NET Core 9
- JWT авторизация (роли: `admin`, `user`)
- CQRS + MediatR
- FluentValidation
- ExceptionHandlingMiddleware
- Swagger UI
- In-Memory хранилище

---

## 🔐 Аутентификация и роли

API защищён с помощью JWT токенов.  
Пользователи имеют роли:
- **admin** — может загружать файлы
- **user** — имеет только права чтения

### 🔑 Получение токена

Отправьте POST-запрос:

```http
POST /auth/login
{
  "username": "admin",
  "password": "password"
}
В ответ:
{
  "token": "eyJhbGciOiJIUzI1NiIsIn..."
}
🧪 Swagger UI
Перейдите в Swagger: https://localhost:{порт}/swagger

Нажмите кнопку Authorize

Введите:
Bearer eyJhbGciOiJIUzI1NiIsIn...
После этого вы сможете вызывать защищённые методы

📤 Загрузка файла
POST /ad-platforms/load
Только для роли admin.

Пример тела запроса:
{
  "fileName": "platforms.txt",
  "fileBase64": "0JfQsNC90LjQvdC+0Lkg0J/RgNC+0L3QtdGA0L7QstCw0YDQvtCyOi9ydQ0K0JHQtdC70Y/QvdC10LrRgtC+INC/0LDRgNC10LvRjNC90YvQuSDQv9GA0L7QstGL0Lkg0YHQtdC70LjQuy86L3J1L3N2cmQvcmV2ZGEsL3J1L3N2cmQvcGVydmlrDQpHdXpldGEgdXJhbGnigJlja2l4IG1vc2t2aWNoZWk6L3J1L21zaywvcnUvcGVybW9ibCwvcnUvY2hlbG9ibA0K0JrQtdGA0LXQvCDQv9GA0L7QstCw0YDQvtCyOi9ydQ=="
}
Файл должен быть в формате:
Яндекс.Директ:/ru
Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik
Газета уральских москвичей:/ru/msk,/ru/permobl,/ru/chelobl
Крутая реклама:/ru/svrd

# REST API Task Tracking App

Учебный проект REST API для управления задачами . Проект демонстрирует навыки бэкенд-разработки на .NET, включая работу с реляционными базами данных, валидацию входных данных и покрытие кода модульными тестами.

## Технологический стек

- Язык: C#
- Фреймворк: .NET (Minimal API)
- База данных: PostgreSQL
- ORM: Entity Framework Core
- Валидация: FluentValidation
- Тестирование: xUnit, EF Core In-Memory Database
- Документация: Swagger / OpenAPI

## Основные возможности

- Полный цикл CRUD-операций для управления задачами.
- Валидация входящих данных с помощью FluentValidation.
- Взаимодействие с базой данных через EF Core с использованием миграций.
- Покрытие бизнес-логики модульными тестами.
- Автоматически генерируемая документация API (Swagger UI).

## Инструкция по запуску

### Требования
- Установленный .NET SDK (версии, используемой в проекте)
- Установленный и запущенный сервер PostgreSQL
- Git

### Установка и настройка

1. Клонируйте репозиторий:
   git clone https://github.com/DuwangKing/REST-API-Task-Tracking-App.git
   cd REST-API-Task-Tracking-App

2. Настройте строку подключения к базе данных. Откройте файл TodoApp/appsettings.json и измените значение DefaultConnection на ваши данные:
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=TodoDb;Username=ваш_пользователь;Password=ваш_пароль"
   }

3. Примените миграции для создания таблиц в базе данных (выполняйте из папки TodoApp):
   dotnet ef database update

4. Запустите приложение:
   dotnet run

5. После запуска документация API будет доступна по адресу:
   http://localhost:5000/swagger 
   (порт может отличаться, проверьте вывод в консоли или файл launchSettings.json).

## Запуск тестов

Для запуска модульных тестов выполните следующую команду из корневой папки решения:

dotnet test TodoApp.Tests

## Доступные эндпоинты

- GET    /api/todos         : Получить список всех задач
- GET    /api/todos/{id}    : Получить задачу по идентификатору
- POST   /api/todos         : Создать новую задачу
- PUT    /api/todos/{id}    : Обновить существующую задачу
- DELETE /api/todos/{id}    : Удалить задачу

## Планы по доработке

- Добавление глобального обработчика исключений (Global Exception Handling).
- Расширение модели задачи полями CreatedAt и UpdatedAt.
- Перевод интеграционных тестов на использование Testcontainers (PostgreSQL в Docker) вместо In-Memory базы данных.
- Реализация аутентификации через JWT-токены.

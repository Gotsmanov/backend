# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем файл решения и проектные файлы в контейнер
COPY *.sln .
COPY YourProjectName/*.csproj ./YourProjectName/

# Восстанавливаем зависимости
WORKDIR /app/YourProjectName
RUN dotnet restore

# Копируем все файлы в контейнер
COPY . .

# Сборка приложения
RUN dotnet publish -c Release -o /app/publish

# Используем минимальный runtime образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Устанавливаем рабочую директорию в контейнере
WORKDIR /app

# Копируем собранное приложение из предыдущего этапа
COPY --from=build /app/publish .

# Указываем порт, на котором приложение будет работать
EXPOSE 80
EXPOSE 443

# Устанавливаем команду запуска приложения
ENTRYPOINT ["dotnet", "backend.dll"]
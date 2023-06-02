# Приятный шелест
Производство печатной продукции в виде газет.

Разрабатываемая система предназначена для автоматизации работы с выпускаемой продукцией, которая включает в себя:
- просмотр списка продукции;
- добавление/удаление/редактирование данных;
- авторизация пользователей и работников;

## Установка
1. Скачать проект
2. Распаковать
3. Зайти в папку и запустить exe файл

### Код
Таблица Users
```
    public partial class Users
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ID_Post { get; set; }
    
        public virtual Post Post { get; set; }
    }
 ```

### Автор работы
**Rovz** [Newspaper](https://github.com/Rovzzz/Newspaper)

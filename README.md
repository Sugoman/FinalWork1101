# FinalWork
 Итоговая работа по МДК \
 Сделал:   Речицкий Александр

### Задания

    1) Папка `files` хранит таблицы и sql-запрос.
    2) DataAccessViaWPF
    3) ApiFrgrantWorld
    4) ProductView
    5) ProductSort

## Примечание 
API имеет свойство удалять собственные css-файлы. Для проверки метода GET:
- `{localhost}/api/Order/{id}`
- `{localhost}/api/PickupPoint/{id}`
- `{localhost}/api/Product/{id}`
- `{localhost}/api/User/{id}`

JSON-файл для тестирования метода POST:

    {
    "OrderId": 21,
    "OrderComposition": "string",
    "OrderCount": 0,
    "OrderDate": "2024-12-18T14:43:19.649Z",
    "OrderDeliveryDate": "2024-12-18T14:43:19.649Z",
    "OrderPickupPointId": 33,
    "OrderClientSurname": "string",
    "OrderClientFirstName": "string",
    "OrderClientPatronymic": "string",
    "OrderCode": 0,
    "OrderStatus": "string",
    "OrderPickupPoint": {
        "PickupPointId": 33,
        "PickupPointIndex":123123,
        "PickupPointCity": "string",
        "PickupPointStreet": "string",
        "PickupPointHouse": 0,
        "Orders": []
    },
    "ProductArticleNumbers": [
        {
        "ProductArticleNumber": "string",
        "ProductName": "string",
        "ProductDescription": "string",
        "ProductCategory": "string",
        "ProductPhoto": "iVBORw0KGgoAAAANSUhEUgAAAAUA",
        "ProductManufacturer": "string",
        "ProductCost": 1231,
        "ProductDiscountAmount": 123,
        "ProductQuantityInStock": 1,
        "ProductStatus": "string",
        "Orders": []
        }
    ]
    }


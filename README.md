Реализовать REST API, с помощью которого регистрировать, отслеживать и управлять заказом, а также получать информацию о постамате. Предполагается, что данное API будет реализовано для интеграции с интернет-магазинами, которые, в свою очередь, будут предоставлять сервис по управлению заказом со своего сайта. Центральная сущность – заказ. Заказ обладает следующими характеристиками: • Номер заказа (int) • Статус заказа (int) • Состав заказа: массив товаров (string[]) • Стоимость заказа (decimal) • Номер постамата доставки (string) • Номер телефона получателя (string) • ФИО получателя (string)

Возможные значения статусов заказа: Зарегистрирован = 1 Принят на складе = 2 Выдан курьеру = 3 Доставлен в постамат = 4 Доставлен получателю = 5 Отменен = 6

Методы по заказу, которые необходимо реализовать: • Создание заказа • Изменение заказа • Получение информации по заказу • Отмена заказа

Второй сущностью является постамат. Постамат характеризуется следующими свойствами: • Номер (string) • Адрес постамата (string) • Статус постамата (bool, Рабочий = true, иначе закрыт)

Методы по постамату, которые необходимо реализовать: • Получение списка рабочих постаматов, отсортированных по номеру в алфавитном порядке • Получение информации о постамате

Требования: Реализовать операции: создание заказа, получение информации о заказе (tracking), обновление информации о заказе, отмена заказа, получение списка постаматов и информации о постамате. • За хранилище заказов и постаматов можно взять любое хранилище, НО, плюсом будет: o реализация CodeFirst на Entity Framework Core (MS SQL/Postgree) o реализация с помощью NoSql DB на выбор. • В случае, если заказ не существует, сообщать код ответа: «не найден». • Поля статус заказа и номер постамата неизменяемые. • В заказ может попадать не более 10 товаров. Если товаров больше, выдавать код ответа «ошибка запроса». • В случае, если указан номер постамата, формат которого некорректен, выдавать ошибку запроса. Формат номера постамата: «XXXX-XXX», где X – это цифра. • В случае, если постамат не существует, сообщать код ответа: «не найден». • Формат номера телефона должен удовлетворять маске «+7XXX-XXX-XX-XX», где вместо X должны стоять цифры. Если номер не соответствует формату, выдавать код ответа «ошибка запроса». • Если идет попытка создать заказ на закрытый постамат – запрещать регистрировать заказ с кодом ошибки «запрещено».

Язык реализации: C#, формат запросов/ответов: JSON, протокол обмена: HTTP.

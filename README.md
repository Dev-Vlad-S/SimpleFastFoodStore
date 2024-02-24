<h1 align="center">
	Магазин быстрого питания
</h1>

<p align="center">
	<img src="/PictureForDescriptionProject/LogoStore.png" width="400">
</p>

<p align="center">
	<img alt="Static Badge" src="https://img.shields.io/badge/.Net_8.0-blue?style=flat">
	<img alt="Static Badge" src="https://img.shields.io/badge/c%23-blue?style=flat">
	<img alt="Static Badge" src="https://img.shields.io/badge/WPF-red?style=flat">
	<img alt="Static Badge" src="https://img.shields.io/badge/Entity%20Framework-pink?style=flat&label=ORM">
	<img alt="Static Badge" src="https://img.shields.io/badge/Sqlite-green?style=flat&label=DB">
</p>

<h2>
	О проекте
</h2>

<p>
	Разработан проект магазина быстрого питания под названием "НАШЕ МЕСТО".
	Данный проект разработан для получения опыта по созданию десктопных приложений со слоистой архитектурой, взаимодействующих с пользователем и работающих с реляционными базами данных.
	Решение включает в себя три проекта: FastFoodStore.DAL (уровень доступа к данным из базы данных Sqlite с помощью EntityFramework), FastFoodStore.BLL (уровень бизнес логики), FastfoodStore.WPFView.MVVM (представление с реализацией паттерна MVVM, в котором используются команды (как наследованные от базовых классов WPF, так и собственные)).
</p>

<h2>
	Визуальная часть проекта
</h2>

<h2>
	Основные графические элементы и их функционал
</h2>

<p>
	Приложение в визуальном плане написано под планшет и состоит из одного окна (Main Window).
	Взаимодействие с пользовательскими графическим интерфесом осуществляется с помощью мыши.
	В левой стороне окна приложения сконцентрированы логотип магазина с кнопками изменения состояния окна <img src="/PictureForDescriptionProject/WindowStateButtons.png" width="60"> (перемещение окна осуществляется при зажатой левой клавиши мыши на изображении логотипа), <img src="/PictureForDescriptionProject/PropertyButton.png" width="20"> настройками стилей и панелью карточек товаров, пользующихся спросом у покупателей.
	В верхней части приложения определены кнопки, с которыми ассоциированы продукты, предлагающие магазин, и корзина.
	Путем нажатия на кнопки происходит переключение между списками продуктов, продающихся в магазине.
</p>

<p align="center">
	<img src="/PictureForDescriptionProject/CommonViewStore.png" width="1280">
</p>

<p>
	При добавлении продукта в корзину запускается анимация его перемещения в корзину и продукт становится неактивным для добавления в корзину.
</p>

<p align="center">
	<img src="/PictureForDescriptionProject/ProcessAddingProductInBasket.gif" width="1280">
</p>

<p>
	Корзина содержит список продуктов, которые туда добавил покупатель и панель о количестве товаров и их стоимости. Покупатель имеет возможность убрать выбранные товары из корзины или отметить галочкой только те товары, которые хочет оплатить.
</p>

<p align="center">
	<img src="/PictureForDescriptionProject/ProcessInBasket.gif" width="1280">
</p>

<h2>
	Стили
</h2>

<p>
	Внешнее оформление можно менять по настроению. Для этого путем многократного нажатия <img src="/PictureForDescriptionProject/PropertyButton.png" width="20"> подбирается оформление магазина.
	Стиль сохраняется в файл ColorTheme.xaml при закрытии приложения и считывается при открытии приложения, далее назначается внешний вид магазину.
	Если удалить файл ColorTheme.xaml, по умолчанию приложение загрузится с темным стилем оформления.
</p>

<p align="center">
	<img src="/PictureForDescriptionProject/StyleDemonstration.gif" width="1280">
</p>


<h2>
	Структура проекта
</h2>

<p>
	Структура проекта представлена в виде UML диаграммы.
</p>

<h2>
	Схема уровня доступа к данным с помощью Entity Framework
</h2>
<p align="center">
	<img align="center"  src="/PictureForDescriptionProject/DAL.svg" width="720px" />
</p>

<h2>
	Схема уровня бизнес логики
</h2>
<p align="center">
	<img align="center"  src="/PictureForDescriptionProject/BLL.svg" width="720px" />
</p>

<h2>
	Схема уровня представления
</h2>
<p align="center">
	<img align="center"  src="/PictureForDescriptionProject/VIEW.svg" width="720px" />
</p>

<h2>
	Внешние источники
</h2>

<h3>
	Картинки продуктов заимствованы с сайта магазина <a href="https://pizzafabrika.ru/">Пицца Фабрика</a>
</h3>

<h2>
	Сопровождение проекта
</h2>

<h3>
Автор проекта: <a href="https://github.com/Dev-Vlad-S">Dev-Vlad-S</a>
</h3>

<h3>
Общее руководство: <a href="https://github.com/anst-foto">anst-foto</a>
</h3>



Задача:Реализовать нетранзитивную игру.
1) Игрок хочет играть в общего вида нетранзитивную игру с одним ходом. Не камень-бумага-ножницы, а любую, какую придумает. Главное - нетранзитивность ходов (второй ход выигрывает у первого, третий выигрывает у второго, но третий проигрывает первому при наличии 3 ходов). Соответственно, в коде не могут быть зашиты любые ходы, они передаются как аргументы.
2) Правила определяются исключительно порядком ходов, а не семантикой. Если игрок хочет поменять правила, он меняет порядок переданных ходов.
3) Число ходов может быть произвольным (нечетным больше 1) — при увеличении числа ходов вероятность ничьей приближается к нулю.
4) Игрок хочет иметь доказательство того, что компьютер не изменил свой ход после хода игрока. Но при этом, конечно, игрок хочет играть "с интересом", т.е. игрок не должен знать и не должен мочь вычислить ход компьютера до своего хода.
5) 
При запуске ***параметрами командной строки*** (аргументы метода main или Main в случае Java или C#, sys.argv в Python, process.argv под Node.js и т.д.) передаётся нечётное число >=3 неповторяющихся строк (при неправильно заданных аргументах необходимо вывести аккуратное сообщение об ошибке — что именно неверно, пример как правильно). Все сообщения на английском языке. Эти строки — это ходы (например, Камень Ножницы Бумага или Камень Ножницы Бумага Ящерица Спок или 1 2 3 4 5 6 7 8 9).

Важно: ***ходы передаются аргументами командной строки***, вы их не парсите из потока ввода (например, ход может содержать пробел, но для вашего кода это не должно иметь никакого значения).

Победа определяется так — половина следующих по кругу выигрывает, половина предыдущих по кругу проигрывает (семантика строк не важна, в какой последовательности что пользователь ввел, в такую игру и играет, даже если по его порядку камень проигрывает ножницам — для вас содержимое строк не важно).
Скрипт генерирует криптографически стойкий случайный ключ (SecureRandom, RandomNumberGenerator и т.п. — обязательно!) длиной не менее 256 бит, делает свой (компьюетра) ход, вычисляет HMAC (на базе SHA2 или SHA3) от хода как сообщения со сгенерированным ключом, показывает пользователя HMAC. После этого пользователь получает "меню" 1 - Камень, 2 - Ножницы, ...., 0 - Exit. Пользователь делает свой выбор (при некорректном вводе опять отображается "меню"). Скрипт показывает кто победил, ход компьютера и исходный ключ.

Таким образом, пользователь может проверить, что компьютер играет честно (не поменял свой ход после хода пользователя).

При выборе опции "help" в терминале нужно отобразить таблицу, определяющую какой ход выигрывает.

Генерация таблицы должна быть вынесена в отдельный класс, определение "правил" кто победил должно быть в отдельном классе, функции генерации ключа и HMAC должны быть в отдельном классе (как минимум 4 класса). По максимуму следует использовать базовые библиотеки классов и сторонние библиотеки, а не изобретать велосипед. Помощь нужно оформлить в виде таблицы N + 1 на N + 1, где N - число ходов (определяется числом переданных в скрипт аргументов). +1 потому, чтобы добавить заголовок для строк и заголовок для колонок (содержат название хода). В ячейках может быть Win/Lose/Draw.

ЧИСЛО ХОДОВ МОЖЕТ БЫТЬ ЛЮБЫМ (нечетным > 1, зависит от переданных параметров), не зашито в коде. 

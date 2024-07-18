# DicePredictor

https://github.com/user-attachments/assets/26b10267-f173-425b-a2a6-9bd7cf2b4c52

# Документация

Процесс выпадения заранее выбранного значения на кубике состоит из 3 этапов:
1. Симуляция падения и покадровое сохранение положения кубика с момента его появления до полной остановки (`RollingPhysicSimulator`);
2. Поворот кубика таким образом, чтобы на самой верхней грани находилось заранее выбранное значение (`DiceFaceModifier`);
3. Воспроизведение сохраненной симуляции (`RollingPhysicPlayer`).

## DiceRoller
Бросает кубики (`Dice`). Задает кубикам случайную начальную скорость, поворот и вращение.

## IRollingModifier
Изменяет способ броска кубиков. Отношение с `IDiceRoller` можно описать паттерном "Декоратор".

## DiceFaceModifier
Изменяет выпавшее значение брошенных кубиков.

1. Начинает работу с симуляции броска кубиков через объект `RollingPhysicSimulator`

https://github.com/amliwada/DicePredictor/blob/b0caa8ebbb8a1722a0914c9555b1a91a0747cb0a/Assets/DicePredictor/Scripts/Modifiers/DiceFaceModifier.cs#L27-L30

Результатом работы симулятора является список кадров, которые хранят положение кубиков в пространстве с момента их броска до полной остановки.

2. После того как все кубики упадут, они поворачиваются таким образом, чтобы верхняя грань показывала на заранее заданное число

https://github.com/amliwada/DicePredictor/blob/b0caa8ebbb8a1722a0914c9555b1a91a0747cb0a/Assets/DicePredictor/Scripts/Modifiers/DiceFaceModifier.cs#L32-L38

3. Через объект `RollingPhysicPlayer` воспроизводится ранее записанная симуляция:

https://github.com/amliwada/DicePredictor/blob/b0caa8ebbb8a1722a0914c9555b1a91a0747cb0a/Assets/DicePredictor/Scripts/Modifiers/DiceFaceModifier.cs#L40-L43

Это необходимо выполнить, чтобы повторный бросок показал тот же результат, который был получен в симуляции.

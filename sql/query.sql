-- Сколько каждого материала должно уходить на каждый заказ? (итоговая сумма)
SELECT o.idorder AS 'Заказ'
      ,o.name AS 'Номер заказа'
      ,m.good_marking AS 'Артикул материала'
      ,SUM(m.qustore * oi.qu) AS 'Итоговая сумма'
FROM view_orders AS o
  JOIN view_orderitem AS oi ON oi.idorder = o.idorder
  JOIN view_modelcalc  AS m ON m.idorderitem = oi.idorderitem
GROUP BY o.idorder
        ,o.name
        ,m.good_marking
ORDER BY o.idorder
        ,m.good_marking;


-- Сколько всего материалов каких материалов должно уйти на все заказы?
SELECT m.good_marking as 'Артикул материала'
      ,SUM(m.qustore * oi.qu) AS 'Количество материала'
FROM view_orders AS o
  JOIN view_orderitem AS oi ON oi.idorder = o.idorder
  JOIN view_modelcalc AS m ON m.idorderitem = oi.idorderitem
GROUP BY m.good_marking
ORDER BY m.good_marking;

-- Сколько и какого материала должно уйти на изделия Окно для продавца Иванова
SELECT m.good_marking AS 'Артикул материала',
    SUM(m.qustore * oi.qu) AS 'Количество материала'
FROM view_orders AS o
JOIN view_orderitem AS oi ON oi.idorder = o.idorder
JOIN view_modelcalc  AS m ON m.idorderitem = oi.idorderitem
WHERE o.seller_name = 'Иванов' AND oi.Name   = 'Окно'
GROUP BY m.good_marking
ORDER BY m.good_marking;

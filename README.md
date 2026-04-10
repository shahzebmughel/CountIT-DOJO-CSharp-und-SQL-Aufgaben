# C# Aufgaben
Ich habe unter Jede Aufgabe statt so:
<p>
<img width="1151" height="475"  alt="image" src="https://github.com/user-attachments/assets/caf7bf9a-1777-420d-b871-0282e9e5963a" />
<img width="558" height="641" alt="image" src="https://github.com/user-attachments/assets/12e6c6a3-6fb6-4b4f-94b9-dec81a902cec" />
</p>
Static hinzugefügt sowie auf dem Beispiel hier oben damit ich das auf einer C# Datei haben konnte. Ich habe selbstverständig das static bei der eigentlichen Aufgabe immer entfernt.
<img width="654" height="438" alt="image" src="https://github.com/user-attachments/assets/6620637b-dca0-4f14-8568-9aa0d8f5d2b4" />

Die Aufgabe Enumeration ist auch hier, habe diese nicht unter der Main Methode
<img width="529" height="749" alt="image" src="https://github.com/user-attachments/assets/fd1306d0-58d6-4f76-8c45-74421f74db08" />




# SQL Aufgaben
## 1. SELECT

SELECT *
FROM OrderArticle;


## 2. WHERE

SELECT Article.Name
FROM Article
WHERE Article.Id = 318


## 3. ODER BY
SELECT TOP 10 Article.Name, Article.Weight, Article.Price
FROM Article 
WHERE Article.Weight < 100
ORDER BY Article.Price DESC


## 4. DISTINCT
SELECT DISTINCT Address.City
FROM  Address

## 5. JOIN
SELECT OA.OrderId, OA.ArticleId, A.Name, OA.Quantity
FROM ORDERARTICLE OA
INNER JOIN [Order] O ON OA.OrderId = O.Id
INNER JOIN Article A ON A.Id = OA.ArticleId;

## 6. Gruppierung
SELECT TOP 10 OA.OrderId, SUM (OA.Quantity) AS Gesamtmenge
FROM ORDERARTICLE OA
INNER JOIN [Order] O ON OA.OrderId = O.Id
INNER JOIN Article A ON A.Id = OA.ArticleId
GROUP BY OA.OrderId


## 7. HAVING
SELECT TOP 10 c.lastName, COUNT(c.lastName) as nameCount
FROM Customer c
GROUP BY c.lastName
HAVING COUNT(c.lastName) > 6

## 8. LIKE
SELECT TOP 5 c.firstName as FirstName, c.lastName as LastName
FROM Customer c
WHERE c.FirstName LIKE 'C%a_'

## 9. SUBQUERY
SELECT Id, Name, Weight
FROM Article 
WHERE Weight = (SELECT Weight 
               FROM Article
               WHERE Id = 319)

## 10. VERGLEICHSOPERATOREN
SELECT *
FROM Customer
WHERE lastName Like 'A%'
AND RegistrationDate > ALL (SELECT RegistrationDate
                         FROM Customer
                         WHERE lastName like 'F%')

## 11. UNION
SELECT TOP 10 Id, Name
FROM Article 
WHERE Weight < 100

UNION

SELECT TOP 5 Id, Name
FROM Article
WHERE Price > 1000

## 12.Komplexes Beispiel I
SELECT TOP 10 
    A.Id, 
    A.Name, 
    A.Weight AS Gewicht
FROM Article A
LEFT JOIN OrderArticle OA ON A.Id = OA.ArticleId
WHERE A.Id <> 897
GROUP BY A.Id, A.Name, A.Weight
HAVING ISNULL(SUM(OA.Quantity), 0) <= ISNULL((SELECT SUM(Quantity) 
                                              FROM OrderArticle 
                                              WHERE ArticleId = 897), 0)
ORDER BY A.Name ASC;


## 13. Komplexes Beispiel II
SELECT 
    A.Id, 
    A.Name
FROM Article A
INNER JOIN OrderArticle OA ON A.Id = OA.ArticleId
GROUP BY A.Id, A.Name
HAVING SUM(OA.Quantity) <= 100 
   AND COUNT(OA.OrderId) <= 10
ORDER BY A.Id ASC;



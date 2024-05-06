SELECT [r].[room_id] FROM rooms r
JOIN bookings b ON b.room_id = r.room_id
WHERE 
((
	GETDATE() NOT BETWEEN b.check_in_date AND b.check_out_date 
) 
OR (r.room_id NOT IN (b.room_id))) AND availability = 1

SELECT * FROM dbo.customers
WHERE last_name LIKE 'S%';

SELECT *
FROM bookings b
LEFT JOIN customers c ON b.customer_id = c.customer_id
WHERE c.first_name = 'Maxim' OR c.email = 'maximfedorov@yahoo.com';

SELECT *
FROM bookings b
INNER JOIN rooms c ON b.room_id = c.room_id
WHERE c.room_id = 2;

SELECT * FROM rooms

SELECT * FROM rooms
WHERE 
(room_id IN 
(
	SELECT room_id FROM bookings b 
	WHERE '2024-05-15' NOT BETWEEN b.check_in_date AND b.check_out_date
) 
OR (room_id NOT IN (SELECT room_id FROM bookings))) AND availability = 1

SELECT booking_id FROM rooms r
JOIN bookings b ON b.room_id = r.room_id
WHERE (GETDATE() NOT BETWEEN b.check_in_date AND b.check_out_date ) AND availability = 1

SELECT * FROM dbo.customers
WHERE last_name LIKE 'S%';

SELECT *
FROM bookings b
INNER JOIN customers c ON b.customer_id = c.customer_id
WHERE c.first_name = 'Maxim' OR c.email = 'maximfedorov@yahoo.com';

SELECT *
FROM bookings b
INNER JOIN customers c ON b.customer_id = c.customer_id
WHERE c.phone_number = '+7 (495) 678-90-12';

SELECT * FROM rooms
WHERE room_id IN 
(SELECT room_id FROM bookings b 
WHERE '2024-04-08' NOT BETWEEN b.check_in_date AND b.check_out_date)
AND availability = 1;
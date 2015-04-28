<?php
/*
** Connect to database:
*/
 
// Connect to the database (hostname, username, password)
$cont = mysql_connect('localhost','root','') 
    or die('Could not connect to the server!');
 

// Select a database:
mysql_select_db('digidatabase') 
    or die('Could not select a database.');
 

$countrow=0;

// Example query: (TOP 10 equal LIMIT 0,10 in SQL)
$SQL = "SELECT   * FROM digidatabase.itemtable";
 
// Execute query:
$result = mysql_query($SQL) 
    or die('A error occured: ' . sql_error());
 
// Get result count:
$Count = mysql_num_rows($result); 
$i=0; 
$c=0;
$countrow=0;

// Fetch rows:
while ($Row = mysql_fetch_assoc($result)) {
 
    
	$flag['item_id'.$i]=$Row['item_id'];
	$flag['cat_id'.$i]=$Row['cat_id'];
	$flag['item_name'.$i]=$Row['item_name'];
	$flag['item_price'.$i]=$Row['item_price'];
	$flag['item_discription'.$i]=$Row['item_discription'];
	$flag['item_status'.$i]=$Row['item_status'];
	$i++;	
}

$flag['countrow']=$i; 



print(json_encode($flag));
mysql_close($cont);
?>


<?php

 
// Connect to the database (hostname, username, password)
$cont = mysql_connect('localhost','root','') 
    or die('Could not connect to the server!');
 

// Select a database:
mysql_select_db('digidatabase') 

    or die('Could not select a database.');
 
$count=0;



// Example query: 
$SQL = "SELECT   * FROM digidatabase.category";
// Execute query:
$result = mysql_query($SQL) 
    or die('A error occured: ' . mysql_error());
 
// Get result count:
$Count = mysql_num_rows($result); 
$i=0; 
$c=0;
$countrow=0;


// Fetch rows:
while ($Row = mysql_fetch_assoc($result)) {
 
    
	$flag['cat_id'.$i]=$Row['cat_id'];
	$flag['cat_name'.$i]=$Row['cat_name'];
	$i++;

	}


$flag['countrow']=$i;

print(json_encode($flag));
mysql_close($cont);
?>
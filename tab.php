<?php

 
// Connect to the database (hostname, username, password)
$cont = mysql_connect('localhost','root','') 
    or die('Could not connect to the server!');
 

$macc=$_REQUEST['mac'];
$typemac = mysql_real_escape_string($macc);
// Select a database:
mysql_select_db('digidatabase') 

    or die('Could not select a database.');
 
$count=0;



// Example query: 
$SQL = "SELECT   tab_id FROM digidatabase.tablemaster";
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
 
    
	$flag['tab_id'.$i]=$Row['tab_id'];



$i++;
	}


if (in_array($typemac, $flag)) {
$d=100;
$flagg['total']=$d;
}
else
{$d=200;
$flagg['total']=$d;
}print(json_encode($flagg));
mysql_close($cont);
?>
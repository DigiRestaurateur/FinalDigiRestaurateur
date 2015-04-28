<?php
$cont = mysql_connect('localhost','root','') 
 or die('Could not connect to the server!');


mysql_select_db('digidatabase')
or die('Could not select a database.');



$name=$_REQUEST['name'];
$typename = mysql_real_escape_string($name);	


$con=$_REQUEST['contact'];
$typecon = mysql_real_escape_string($con);

$k=0;
$c=0;
$cc=0;
$otid=0;
//------------------------------------------counting
$SQL = "SELECT   cust_id  FROM digidatabase.customertable where cust_name='$typename'  AND cust_contact='$typecon'";
$result = mysql_query($SQL) 
    or die('A error occured: ' . mysql_error());
// Get result count:
$Count = mysql_num_rows($result); 
// Fetch rows:
while ($Row = mysql_fetch_assoc($result)) {

	$cc=$Row['cust_id'];
	
	$k++;
	}
$flag['otid']=$cc;

	print(json_encode($flag));
	mysql_close($cont);
?>


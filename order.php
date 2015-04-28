<?php
$cont = mysql_connect('localhost','root','') 
 or die('Could not connect to the server!');


mysql_select_db('digidatabase')
or die('Could not select a database.');
	 
$order_id=$_REQUEST['order_id'];
$typeoid= mysql_real_escape_string($order_id);

$table_id=$_REQUEST['table_id'];
$typetid = mysql_real_escape_string($table_id);

$order_itid=$_REQUEST['order_itid'];
$typeitid = mysql_real_escape_string($order_itid);	

$order_item=$_REQUEST['order_item'];
$typeoitem = mysql_real_escape_string($order_item);	

$order_price=$_REQUEST['order_price'];
$typeprice = mysql_real_escape_string($order_price);

$order_quantity=$_REQUEST['order_quantity'];
$typeqty = mysql_real_escape_string($order_quantity);	

	

$order_ototal=$_REQUEST['order_ototal'];
$typeototal= mysql_real_escape_string($order_ototal);	


$order_tips=$_REQUEST['order_tips'];
$typetips = mysql_real_escape_string($order_tips);	

$order_status=$_REQUEST['order_status'];
$typestatus = mysql_real_escape_string($order_status);	

$dt=date("h:i:s A");
$typed = mysql_real_escape_string($dt);	

$flag['code']=0;


$query= "insert into digidatabase.ordertable values('$typeoid','$typetid','$typeitid','$typeoitem','$typeprice','$typeqty','$typeototal','$typetips','$typestatus','$typed')";



mysql_query($query) 

or trigger_error(mysql_error()." in ".$query);

	{
		$flag['code']=1;
		echo"hi";
	}

	print(json_encode($flag));
	mysql_close($cont);
?>
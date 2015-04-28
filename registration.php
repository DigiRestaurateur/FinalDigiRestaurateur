<?php
$cont = mysql_connect('localhost','root','') 
 or die('Could not connect to the server!');


mysql_select_db('digidatabase')
or die('Could not select a database.');

	 

$namee=$_REQUEST['name'];
$typename = mysql_real_escape_string($namee);

$conn=$_REQUEST['contact'];
$typecon = mysql_real_escape_string($conn);	



//---------------------------
$j=1;
$i=0;
$cc=0;
$cnt=0;
$SQL = "SELECT   cust_count  FROM digidatabase.customertable where cust_name='$typename' and cust_contact='$typecon'";
$result = mysql_query($SQL) 
    or die('A error occured: ' . mysql_error());
// Get result count:
$Count = mysql_num_rows($result); 
// Fetch rows:
while ($Row = mysql_fetch_assoc($result)) {

	$cc=$Row['cust_count'];
	
	$j++;
	}
if($cc==0)
{$cc=$cc+1;
}
else if($cc!=0)
{$cc=$cc+1;
}


$cnt=$cc;
//-----------------------------------------
$flag['code']=$cc;

if($cnt==1)
{
$query= "insert into digidatabase.customertable (cust_name,cust_contact,cust_count) values('$typename','$typecon','$cnt')";
mysql_query($query) 

or trigger_error(mysql_error()." in ".$query);

	{
		$flag['cnt']=100;
		echo"hi";
	}

}
else
{
//-------------------------

$query1= "update digidatabase.customertable set cust_count='$cnt' where cust_name='$typename'";
mysql_query($query1) 

or trigger_error(mysql_error()." in ".$query1);

	{
		$flag['cnt']=200;
		echo"hi";
	}
$j=0;
$cnt=0;
$cc=0;
//--------------------------
}


	print(json_encode($flag));
	mysql_close($cont);
?>

<?php
$cont = mysql_connect('localhost','root','') 
 or die('Could not connect to the server!');


mysql_select_db('digidatabase')
or die('Could not select a database.');


$name=$_REQUEST['name'];
$typename = mysql_real_escape_string($name);	


$con=$_REQUEST['contact'];
$typecon = mysql_real_escape_string($con);

$feed=$_REQUEST['feed'];
$typefeed = mysql_real_escape_string($feed);	
$k=0;
$c=0;
$cc=0;
//------------------------------------------counting
$SQL = "SELECT   cust_count  FROM digidatabase.customertable where cust_name='$typename'  AND cust_contact='$typecon'";
$result = mysql_query($SQL) 
    or die('A error occured: ' . mysql_error());
// Get result count:
$Count = mysql_num_rows($result); 
// Fetch rows:
while ($Row = mysql_fetch_assoc($result)) {

	$cc=$Row['cust_count'];
	
	$k++;
	}
$c=$cc;
$flag['code']=$c;
$i=0;
$ca=0;
$cat=0;
$j=0;
//------------
$SQL = "SELECT   cust_id  FROM digidatabase.customertable where cust_name='$typename'  AND cust_contact='$typecon' ";
$result = mysql_query($SQL) 
    or die('A error occured: ' . mysql_error());
// Get result count:
$Count = mysql_num_rows($result); 
// Fetch rows:
while ($Row = mysql_fetch_assoc($result)) {

	$ca=$Row['cust_id'];
	
	$j++;
	}

//-------
$cat=$ca;
//---------------------------------
//$flag['cat']=$cat;
//in user info table
$abc=0;
$m=0;
$SQL2 = "SELECT   user_id  FROM digidatabase.userinfo where  user_id='$ca' AND user_count='$c'  ";
$result = mysql_query($SQL2) 
    or die('A error occured: ' . mysql_error());
// Get result count:
$Count = mysql_num_rows($result); 
// Fetch rows:
while ($Row = mysql_fetch_assoc($result)) {

	$abc=$Row['user_id'];
	
	$m++;
	}

//--------------------------

$flag['code']=0;

if($abc==0)
{
$query= "insert into userinfo values ('$cat','$c ','$typefeed')";

mysql_query($query) 

or trigger_error(mysql_error()." in ".$query);

	{
		$flag['code']=1;
		echo"hi";
	}

}
else if($abc!=0)
{
$query= "update userinfo set user_id ='$cat',user_count='$c ',user_feedback='$typefeed' where user_id='$cat'";

mysql_query($query) 

or trigger_error(mysql_error()." in ".$query);

	{
		$flag['code']=150;
		echo"hi";
	}

}
//$flag['code']=$c;

	print(json_encode($flag));
	mysql_close($cont);
?>


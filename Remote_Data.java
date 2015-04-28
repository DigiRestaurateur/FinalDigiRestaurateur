package com.example.digi_restaurateur;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.LauncherActivity.ListItem;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.AsyncTask;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class Remote_Data extends AsyncTask<String,Void,String> 
{
	 HttpResponse response;
	 HttpGet request ;
	 URL url;
int did=0;
	 String odate,strLink,a,Str1,Str2,cnt,strId,strName,strContact,strUserId,strUserName,strUserCon,O_OID,O_TID,O_OITID,O_ITEMS,O_PRICE,O_QTY,O_OTOTAL,O_STATUS,O_TIPS,usrnm,con,macid;	
	 HttpClient client;
	 EditText etxt1,etxt2,etxt3;
	 TextView txt1,txt2;
	 Context context;
	public static int otbid=0;
	public static int orderid=0;
	public static String ok,r1,r2,r3,r4,r5,r6,lo;
	public static long l=0;
	public static String ok1,or;
	public static int ok2=10;
	public static int j=0;
	DatabaseHandler db,db1;



    public String getDateTime()
{
	SimpleDateFormat dateformat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss",Locale.getDefault());
	Date date=new Date();
	return dateformat.format(date);
}	
	
	public Remote_Data(Context context,int did)
	{//4
		this.context=context;
		this.did=did;

		a="did";
		//regi
	}
	public Remote_Data(Context context,EditText etxt1,EditText etxt2)
	{//4
		this.context=context;
		
		this.etxt1=etxt1;
		this.etxt2=etxt2;

		a="userreg";
		//regi
	}
	
	public Remote_Data(Context context,String strUserName,String strUserCon,int s,int p)
	{//4
		this.context=context;
	
		this.strUserName=strUserName;
		this.strUserCon=strUserCon;

		a="skipreg";
		//skipreg
	}
	public Remote_Data(Context context,String selectall,String Str1)
	{//3
		this.context=context;		
		a="selectall";		
	//selectall
		
	}

	public Remote_Data(Context context,String selectcat)
	{//1
		this.context=context;
		a="selectcat";
	//selectcat
		
	}
	
	
	public Remote_Data(Context context,String strUserName,String strContact,EditText etxt3)
	{
		this.context=context;		
		this.strUserName=strUserName;
		this.strContact=strContact;
		this.etxt3=etxt3;
		a="feedback";
		//feedback
	}
	
	public Remote_Data(Context context,String O_OID,String O_TID,String O_OITID,String O_ITEMS,String O_PRICE,String O_QTY,String O_OTOTAL,String tips,String O_STATUS)
	{
		this.context=context;
		this.O_OID=O_OID;
		this.O_TID=O_TID;
		this.O_OITID=O_OITID;
		this.O_ITEMS=O_ITEMS;
		this.O_PRICE=O_PRICE;
		this.O_QTY=O_QTY;
		this.O_OTOTAL=O_OTOTAL;
		this.O_TIPS=tips;
		this.O_STATUS=O_STATUS;
		this.odate=getDateTime();
		a="ordering";
		or=""+O_ITEMS+O_OITID+O_OTOTAL+O_OID+O_TID+O_PRICE+O_QTY+O_STATUS;
        		}
	
	public Remote_Data(Context context,String strUserName,String strContact,int ii)
	{//1
		this.context=context;

		this.strUserName=strUserName.toString();
		this.strContact=strContact.toString();
		a="otid";
		otbid=20;

		//orderid=100;
	//selectcat
		
	}	
	
	public Remote_Data(Context context,String special,int i)
	{//1
		this.context=context;
		a="special";
	//selectcat
		
	}
	public Remote_Data(Context context,String macid,int i,int ii,int iii)
	{//1
		this.context=context;
		this.macid=macid.toString();
		a="mac";
			//selectcat
		
	}
	/*
	public Remote_Data(Context context,EditText etxt1,EditText etxt2,EditText etxt3)
	{
		this.context=context;		
		this.etxt1=etxt1;
		this.etxt2=etxt2;
		this.etxt3=etxt3;
		a="pune";
		//feedback
	}
	public Remote_Data(Context context,String id,String name,String conn)
	
	{
		this.context=context;		
		this.id=id;
		this.name=name;
		this.conn=conn;
		a="rec";
		//feedback
	}
	
	public Remote_Data(Context context,String id)
	{
		this.context=context;		
		
		a="rec1";
		//feedback
	}*/
	@Override
	protected String doInBackground(String... arg0) 
	{
		// TODO Auto-generated method stub	
		
        try {
        	
        	if(a=="userreg")
        	{
        		String strName= etxt1.getText().toString().replaceAll("\\s+","_");	
        		String con=etxt2.getText().toString();		
        		//1st col    
        		
        	strLink = "http://192.168.0.65/registration.php?name="+strName+"&contact="+MainActivity.Contact.toString();
        	//	strLink = "http://192.168.4.131/registration.php?name="+strName+"&contact="+MainActivity.Contact.toString();
                
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        		lo=MainActivity.Contact.toString();
        	}
        	else if(a=="did")
        	{
        		int ddid=did;	
        	strLink = "http://192.168.0.65/deleteorder.php?id="+ddid;
        	//	strLink = "http://192.168.4.131/registration.php?name="+strName+"&contact="+MainActivity.Contact.toString();
                
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        		
        	}
        	else if(a=="skipreg")
        	{
        		String strUserName1= strUserName.toString().replaceAll("\\s+","_");	
        		String strUserCon1=strUserCon.toString().replaceAll("\\s+","_");	
        		//1st col    
        		
        	strLink = "http://192.168.0.65/registration.php?name="+strUserName1+"&contact="+strUserCon1;
        	//	strLink = "http://192.168.4.131/registration.php?name="+strName+"&contact="+MainActivity.Contact.toString();
                
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        	
        	}
        	//strUserName
        	else if(a=="otid")
        	{

        		String strName1=strUserName.toString().replaceAll("\\s+","_");	
        		String con=strContact.toString();
        		//1st col    
        		otbid=15;

        		strLink = "http://192.168.0.65/table.php?name="+strName1+"&contact="+con;
        		//strLink = "http://192.168.0.65/table.php?name=md&contact=8888888888";
            	 
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        		
        	} 
        	else if(a=="special")
        	{
        		
        	strLink = "http://192.168.0.65/special.php";
        	//	strLink = "http://192.168.4.131/registration.php?name="+strName+"&contact="+MainActivity.Contact.toString();
                
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        	}
	        	        
        	else if(a=="selectcat")
        	{
        		strLink = "http://192.168.0.65/selectcat.php";
        		//strLink = "http://192.168.4.131/selectcat.php";
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        	}
  
        	else if(a=="selectall")
        	{
        		strLink = "http://192.168.0.65/selectall.php";
        		//strLink = "http://192.168.4.131/selectall.php";
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        		ok1="kk";
        	}
        	else if(a=="mac")
        	{
        		String mac1=macid.toString();
        		
        		strLink = "http://192.168.0.65/tab.php?mac="+MainActivity.address.toString();
        		//strLink = "http://192.168.4.131/selectall.php";
        		url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);
        		
        	}
//tab.php?mac        	
        	else if(a=="feedback")
        	{
//      		strLink = "http://www.rnetsoft.com/feedback.php?name="+strName+"&con="+con+"&feedback="+feed;
            	
        		String strName=strUserName.toString();
        		String strCon=strContact.toString();
            	String feed=etxt3.getText().toString().replaceAll("\\s+","_");	
            	strLink = "http://192.168.0.65/feedback.php?name="+strName+"&contact="+strCon+"&feed="+feed;
            	//strLink = "http://192.168.4.131/feedback.php?name="+strName+"&contact="+strCon+"&feed="+feed;
            	url = new URL(strLink);
        		client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		response = client.execute(request);        		        
        	}
        	else if(a=="ordering")
        	{
        		String O_OID1=O_OID.toString();
        		String O_TID1=O_TID.toString();
        		String O_OITID1=O_OITID.toString();
        		String O_ITEMS1=O_ITEMS.toString().replaceAll("\\s+","_");
        		String O_PRICE1=O_PRICE.toString();
        		String O_QTY1=O_QTY.toString();
        		String O_OTOTAL1=O_OTOTAL.toString();
        		String O_TIPS1=O_TIPS.toString().replaceAll("\\s+","_");
        		String O_STATUS1=O_STATUS.toString();
        		String orderdate=odate.toString().replaceAll("\\s+","_");
        		     
        		
            	strLink="http://192.168.0.65/order.php?order_id="+O_OID1+"&table_id="+O_TID1+"&order_itid="+O_OITID1+"&order_item="+O_ITEMS1+"&order_price="+O_PRICE1+"&order_quantity="+O_QTY1+"&order_ototal="+O_OTOTAL1+"&order_tips="+O_TIPS1+"&order_status=Pending"+"&order_date="+orderdate;
        		//strLink="http://192.168.0.65/order.php?order_id="+O_OID1+"&table_id="+O_TID1+"&order_itid="+O_OITID1+"&order_item="+O_ITEMS1+"&order_price="+O_PRICE1+"&order_quantity="+O_QTY1+"&order_ototal="+O_OTOTAL1+"&order_status=Pending";
        		//or=""+O_ITEMS1+O_OITID1+O_OTOTAL1+O_OID1+O_TID1+O_PRICE1+O_QTY1+O_STATUS1;
            	
        		url = new URL(strLink);
            	
            	client = new DefaultHttpClient();
        		request = new HttpGet();
        		request.setURI(new URI(strLink));
        		
        		response = client.execute(request);
        		
        	}
        	
        		
        
	        BufferedReader in = new BufferedReader
          		  (new InputStreamReader(response.getEntity().getContent()));

            StringBuffer sb = new StringBuffer("");
            String line="";
            while ((line = in.readLine()) != null) {
          	  sb.append(line);
          	  break;
          	  
            }
            
            in.close(); 
            
            return sb.toString();
            
		
     }
        
        catch (Exception e) 
        {
			// TODO Auto-generated catch block
			 return new String("Exception: " + e.getMessage());
		}

		
		 
	}
	  @Override
	   protected void onPostExecute(String result)
	  {
		  
		  try {
			  JSONObject json_data;
			  
			  if(a=="selectcat")
			  {		
				  json_data = new JSONObject(result);
				  db= new DatabaseHandler(context);

				  int count=Integer.parseInt(json_data.getString("countrow"));			
				  for(int  i=0;i<count;i++)
					{  
					  	String cat_id=json_data.getString("cat_id"+i).toString();				
					  	int g=db.categoryCheck(cat_id);
				
							if(g==1)				  
							{
					
							}
							else
							{	
								String c=json_data.getString("cat_id"+i).toString();
								String cc= json_data.getString("cat_name"+i).toString();
								db.createToDo(c,cc);
				
							}	
					}		 	 		
			  }
		
			  else if(a=="selectall")
			  {
				  	json_data = new JSONObject(result);
				  	db1= new DatabaseHandler(context);
				  	int count=Integer.parseInt(json_data.getString("countrow"));				 
			  
				  	for(int  i=0;i<count;i++)
				  	{
				  		String item_id=json_data.getString("item_id"+i).toString();				
			 			int g=db1.menuCheck(item_id);
			 		
						if(g==1)				  
						{	
							
							long one=Integer.parseInt(json_data.getString("item_id"+i).toString());
							
							String ctid= json_data.getString("cat_id"+i).toString();
							String iname=json_data.getString("item_name"+i).toString();
							String price= json_data.getString("item_price"+i).toString();
							String desc= json_data.getString("item_discription"+i).toString();
							String status=json_data.getString("item_status"+i).toString();
						
							db1.updateMenu(one,ctid,iname,price,desc,status);
							ok2=100;
						}
						
						else
						{
							ok2=20;
							String one=json_data.getString("item_id"+i).toString();
							r1=json_data.getString("item_id"+i).toString();
						
							String ctid= json_data.getString("cat_id"+i).toString();
							r2=json_data.getString("cat_id"+i).toString();
						
							String iname=json_data.getString("item_name"+i).toString();
							r3=json_data.getString("item_name"+i).toString();
						
							String price= json_data.getString("item_price"+i).toString();
							r4=json_data.getString("item_price"+i).toString();
														
							String desc= json_data.getString("item_discription"+i).toString();
							r5=json_data.getString("item_discription"+i).toString();
						
							String status=json_data.getString("item_status"+i).toString();
							r6=json_data.getString("item_status"+i).toString();
						
							
							l=db1.createTODOTAG(one,ctid,iname,price,desc,status);					
							
						}	
				  	}
			  }	
			  else if(a=="otid")
			  {		
				  json_data = new JSONObject(result);
				  db= new DatabaseHandler(context);

				  orderid=Integer.parseInt(json_data.getString("otid"));			
				  DatabaseHandler.o_otid=orderid;
						  otbid=orderid;	
					
			  }
			  else if(a=="special")
			  {		
				  json_data = new JSONObject(result);
				 String sp=json_data.getString("offer").toString().replaceAll("\\s+","_");			
			todaysspecial.todayspecial=sp.toString().replaceAll("\\s+","_");
						  	
					
			  }
			  else if(a=="mac")
			  {	//	ok="macid"+result;
				  json_data = new JSONObject(result);
						
				  String sp=json_data.getString("total").toString();	
				 
			MainActivity.macid=sp.toString();
			  	
					
			  }
			 			  		
			 
	  }

	
		  catch (JSONException e) 
		  {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	
	 
	  
	  }
	 
}

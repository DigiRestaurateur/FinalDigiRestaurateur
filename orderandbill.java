package com.example.digi_restaurateur;

import android.os.Bundle;
import android.os.CountDownTimer;
import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class orderandbill extends Activity 
{
	Button btnSubmit;
	TextView billing;
    
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
    	super.onCreate(savedInstanceState);
        setContentView(R.layout.orderandbill);
        btnSubmit=(Button)findViewById(R.id.button1);
billing=(TextView)findViewById(R.id.textView4);
        loadbill();
        btnSubmit.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v) 
   			{
   				// TODO Auto-generated method stub
   				
   				 CountDownTimer waitTimer = new CountDownTimer(120000, 1000) {
   				 

			       public void onTick(long millisUntilFinished) {
			    	  // Toast.makeText(orderandbill.this,"start", 1).show(); 
			    	   //called every 300 milliseconds, which could be used to
			          //send messages or some other action
			    	  order.click=1;
			       }

			       public void onFinish() {
			          //After 60000 milliseconds (60 sec) finish current 
			    	   Toast.makeText(orderandbill.this,"stop", 1).show();  //if you would like to execute something when time finishes          
			     order.click=2;
			       }
			     }.start();
			     
			    
			     sending();
   				
   				Intent i=new Intent(orderandbill.this,logout.class);
   				startActivity(i);
   				
   			 finish();
   				}
   			
   			
   		});
    }

public void sending() 
{		

DatabaseHandler db = new DatabaseHandler(getApplicationContext());
   				Cursor c = (Cursor) db.getAllMenu2();
				if (c.moveToFirst())
				{
			
					do{
						DisplayContact(c);
						} while (c.moveToNext());
					Toast.makeText(orderandbill.this, "Your order is sending to kitchen...Wait for some time",5).show();
			 		
				}
				
				else
				{Toast.makeText(getBaseContext(),"no data found.. ",
						Toast.LENGTH_LONG).show();
					
				}
				db.close();
				
}			
            
 
			private void DisplayContact(Cursor c)
			{
			/*	Toast.makeText(getBaseContext(),"oid " + c.getString(0)+
					"otid " + c.getString(1)+
					"\n" +"oid " + c.getString(2) + 
					"\n" +"onm: " + c.getString(3).replaceAll("\\s+","_") +
					"\n" +"oprc" + c.getString(4) +
					"\n" +"oqty" + c.getString(5) +
					"\n" +"ottl" + c.getString(6) +
					"\n" +"osts" + c.getString(7),
					Toast.LENGTH_SHORT).show();
				//String h=c.getString(3).replace(" ","");
			*/	String tip=order.tips.toString();
				tip.replaceAll("\\s+","_");
						
			new Remote_Data(getApplicationContext(),c.getString(0),c.getString(1),c.getString(2),c.getString(3),c.getString(4),c.getString(5),c.getString(6),tip,c.getString(7)).execute("");
			//	Toast.makeText(orderandbill.this, ""+Remote_Data.or.toString()+""+tip,5).show();
			Toast.makeText(getBaseContext()," "+c.getString(2),
					1).show();
				
			}
	


    @Override
    public boolean onCreateOptionsMenu(Menu menu) 
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    public void loadbill()
    {	DatabaseHandler db = new DatabaseHandler(getApplicationContext());
			
    	//String bill=db.bill();
    	int bill=db.billingData();
    	Toast.makeText(orderandbill.this, ""+String.valueOf(bill),5).show();
    billing.setText(String.valueOf(bill));	
    }
}



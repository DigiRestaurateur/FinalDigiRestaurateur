package com.example.digi_restaurateur;


import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.text.BreakIterator;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import com.example.digi_restaurateur.DatabaseHandler;


import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.os.Handler;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;


public class MainActivity extends Activity 
{ 	public static Handler handler=new Handler();
	public static int skip=0;
	public static String UserName="",Contact="",tbl="",macid="500",address="";
	
	
	Button btnRegister,btnSkip,btnSetting;
	EditText etxTableNumber,etxUserName,etxContact;	
	String selectCategory1,selectAll,selectCategory2,special,mac;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) 
	{call();
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
			btnRegister=(Button)findViewById(R.id.button7);
	        btnSkip=(Button)findViewById(R.id.button1);
	        btnSetting=(Button)findViewById(R.id.button2);
	        etxTableNumber=(EditText)findViewById(R.id.editText1);
	        etxUserName=(EditText)findViewById(R.id.editText2);
	        etxContact=(EditText)findViewById(R.id.editText3);  
   			
	        btnRegister.setOnClickListener(new OnClickListener() 
	        {
			
				@Override
				public void onClick(View v)
				{
					// TODO Auto-generated method stub
					tbl=etxTableNumber.getText().toString();
					    UserName=etxUserName.getText().toString();						
				        Contact=etxContact.getText().toString();
				       // etxContact.getText().toString().trim();
				 
				 
				 macid="100";
				  if(macid.equals("100")==true)
				        {
				        	
				        	
				        	if(etxContact.length()==10==true)
				    	{
				    		//call userreg constructor
				    	int ii=0;
				    
				    	new Remote_Data(getApplicationContext(),etxUserName,etxContact).execute("");
				    	Intent i=new Intent(MainActivity.this,homepanel.class);
				    		startActivity(i);
				    	finish();	
				      	}
				     else
				     	{
				    	 	Toast.makeText(MainActivity.this,"NO", Toast.LENGTH_LONG).show();
				     	}
				//final();
					}
				        else
				        {
				        	Toast.makeText(MainActivity.this,"invalid tablet", Toast.LENGTH_LONG).show();
				    		
				        }
				}
			});

	        btnSkip.setOnClickListener(new OnClickListener() 
	        {
		       	
			@Override
			public void onClick(View v) 
			{
				 if(macid.equals("100")==true)
			        {
				tbl=etxTableNumber.getText().toString();
						
				// TODO Auto-generated method stub
					skip=100;
					String skipname="Table".concat(etxTableNumber.getText().toString());
					String skipcon="0";
					int s=1,k=1;
					new Remote_Data(getApplicationContext(),skipname,skipcon,s,k).execute("");
			    					
					Intent i=new Intent(MainActivity.this,homepanel.class);
					startActivity(i);
					Toast.makeText(MainActivity.this, "welcome to Home Panel",5).show();
					 finish();
			        }
			        
				 
			       else
			        {
			        	Toast.makeText(MainActivity.this,"invalid tablet", Toast.LENGTH_LONG).show();
			    		
			        }
			 
				

			}
		});

	        	btnSetting.setOnClickListener(new OnClickListener() 
	        	{
					
					@Override
					public void onClick(View arg0) 
					{
						// TODO Auto-generated method stub
					//start fetching
						String d=da();
						Toast.makeText(MainActivity.this,""+d.toString(),5).show();
						
						new Remote_Data(getApplicationContext(),selectAll,selectCategory2).execute("");
				//special		
								int i=1;
								new Remote_Data(getApplicationContext(),special,i).execute("");
										
								
									Toast.makeText(MainActivity.this, "selectAll",Toast.LENGTH_SHORT).show();
									//Toast.makeText(MainActivity.this,""+Remote_Data.ok1,Toast.LENGTH_LONG).show();
									Toast.makeText(MainActivity.this,""+Remote_Data.ok2+""+todaysspecial.todayspecial,Toast.LENGTH_SHORT).show();
									new Remote_Data(getApplicationContext(),selectCategory1).execute("");
									Toast.makeText(MainActivity.this,"selectCategory1",Toast.LENGTH_SHORT).show();
									//final();
									WifiManager manager = (WifiManager) getSystemService(MainActivity.WIFI_SERVICE);
									WifiInfo info = manager.getConnectionInfo();
									 address = info.getMacAddress();
									
									int l=10,k=10,j=50;
									new Remote_Data(getApplicationContext(),address,l,k,j).execute("");
									Toast.makeText(MainActivity.this,""+address+""+Remote_Data.ok,Toast.LENGTH_SHORT).show();
										
						if(macid.equals("100")==true)
							{Toast.makeText(MainActivity.this,"mac"+address,Toast.LENGTH_LONG).show();
							}
						else
						{
							Toast.makeText(MainActivity.this,"no",Toast.LENGTH_LONG).show();
							
						}
/*		Toast.makeText(MainActivity.this,""+Remote_Data.r1,Toast.LENGTH_LONG).show();
		Toast.makeText(MainActivity.this,""+Remote_Data.r2,Toast.LENGTH_LONG).show();
		Toast.makeText(MainActivity.this,""+Remote_Data.r3,Toast.LENGTH_LONG).show();
		Toast.makeText(MainActivity.this,""+Remote_Data.r4,Toast.LENGTH_LONG).show();
		Toast.makeText(MainActivity.this,""+Remote_Data.r5,Toast.LENGTH_LONG).show();
		Toast.makeText(MainActivity.this,""+Remote_Data.r6,Toast.LENGTH_LONG).show();
	*/						   
		/*				new Thread(new Runnable() {
							public void run() {
								String myData = null;
								
									try {
										Thread.sleep(3000);	
										Toast.makeText(MainActivity.this,"selectCategory1",Toast.LENGTH_SHORT).show();
										
									} catch (Exception e) {
										// wait 30 seconds
										Toast.makeText(MainActivity.this,""+e.toString(),Toast.LENGTH_SHORT).show();
										
										// try again
										
									}
								
							}
						}).start();		*/
									}
				});
	        	
				
	}

	  public String da()
	  {
	  	SimpleDateFormat dateformat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss",Locale.getDefault());
	  	Date date=new Date();
	  	return dateformat.format(date);
	  }
	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	public void call()
	{  
	handler.postDelayed(new Runnable() {
        public void run() {
    		//Toast.makeText(MainActivity.this,"thread",1).show();
    		          // this method will contain your almost-finished HTTP calls
        	new Remote_Data(getApplicationContext(),selectAll,selectCategory2).execute("");
			//special		
							int i=1;
							new Remote_Data(getApplicationContext(),special,i).execute("");
							new Remote_Data(getApplicationContext(),selectCategory1).execute("");
							Toast.makeText(MainActivity.this,"selectCategory1",1000).show();
												
							
							handler.postDelayed(this, 300000);
            
        }
       
        
    }, 300000);
				
	
	}

}

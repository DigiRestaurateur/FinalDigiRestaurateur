package com.example.digi_restaurateur;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.List;


import android.net.Uri;
import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.AssetManager;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Toast;

public class homepanel extends Activity 
{
	Button btnMenu,logout,help;
	Button btnGallary;
	Button btnTodaysSpecial;
	Button btnFeedback;   
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
     	
    	
        
        super.onCreate(savedInstanceState);
        setContentView(R.layout.homepanel);
          
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    getid();
    
      btnMenu=(Button)findViewById(R.id.button1);
        btnTodaysSpecial=(Button)findViewById(R.id.button5);
        help=(Button)findViewById(R.id.button3);
        btnFeedback=(Button)findViewById(R.id.button7);
        logout=(Button)findViewById(R.id.button2);
        

        
        help.setOnClickListener(new OnClickListener() 
        {
			
			@Override
			public void onClick(View v) 
			{
				CopyAssets();
			}
		});
     
        btnMenu.setOnClickListener(new OnClickListener() 
        {
			
			@Override
			public void onClick(View v) 
			{
				// TODO Auto-generated method stub
				Intent i=new Intent(homepanel.this,menu.class);
				startActivity(i);
				Toast.makeText(homepanel.this, "Welcome to Menu",5).show();

			}
		});
     
          
     
     btnTodaysSpecial.setOnClickListener(new OnClickListener() 
     	{
			
			@Override
			public void onClick(View v) 
			{
				// TODO Auto-generated method stub
				if(MainActivity.skip==100==true)
					{
					Toast.makeText(homepanel.this, "You are not registered Customer",5).show();
					
					}
				else
				{
					Intent i=new Intent(homepanel.this,todaysspecial.class);
					
					startActivity(i);
					Toast.makeText(homepanel.this, "Welcome to Todays special",5).show();
				}
			}
		});
  
     
    

  
     btnFeedback.setOnClickListener(new OnClickListener() 
     	{
			
			@Override
			public void onClick(View v) {
				
				if(MainActivity.skip==100==true)
				{
					Toast.makeText(homepanel.this, "You are not registered Customer",5).show();
				}
				else
				{
				// TODO Auto-generated method stub
				Intent i=new Intent(homepanel.this,feedback.class);
				startActivity(i);
				Toast.makeText(homepanel.this, "Welcome to Feedback",5).show();
				}
			}
		});
     
     logout.setOnClickListener(new OnClickListener() 
  	{
			
			@Override
			public void onClick(View v) {
				
				MainActivity.UserName="";
				MainActivity.Contact="";
				MainActivity.tbl="";
				MainActivity.macid="500";
				MainActivity.address="";
				
				DatabaseHandler.o_otid=0;
				menu.flag=0;
				menu.pitem="";
				
				menu.selectedItem="";
				menu.psortv="";
				menu.l=0;
				order.tips="";
			todaysspecial.todayspecial="wait...";
			Remote_Data.otbid=0;
			Remote_Data.orderid=0;
			Remote_Data.ok="";
			Remote_Data.lo="";
			Remote_Data.l=0;
			Remote_Data.ok1="";
			Remote_Data.or="";
			Remote_Data.ok2=10;
			Remote_Data.j=0;
			order.click=1;
			 finish();
			}
			
		});
    }
    
    private void CopyAssets() {

        AssetManager assetManager = getAssets();

        InputStream in = null;
        OutputStream out = null;
        File file = new File(getFilesDir(), "TabletManual.pdf");
        try {
            in = assetManager.open("TabletManual.pdf");
            out = openFileOutput(file.getName(), Context.MODE_WORLD_READABLE);

            copyFile(in, out);
            in.close();
            in = null;
            out.flush();
            out.close();
            out = null;
        } catch (Exception e) {
            Log.e("tag", e.getMessage());
        }

        Intent intent = new Intent(Intent.ACTION_VIEW);
        intent.setDataAndType(
                Uri.parse("file://" + getFilesDir() + "/TabletManual.pdf"),
                "application/pdf");

        startActivity(intent);
    }

    private void copyFile(InputStream in, OutputStream out) throws IOException {
        byte[] buffer = new byte[1024];
        int read;
        while ((read = in.read(buffer)) != -1) {
            out.write(buffer, 0, read);
        }
    }


public void getid()
{
	int i=0;
	// TODO Auto-generated method stub
	//Intent i=new Intent(homepanel.this,callaries.class);
	//startActivity(i);
	//new Remote_Data(getApplicationContext(),etxUserName,etxContact,i).execute("");
int ii=0;
String unm=MainActivity.UserName.toString().replaceAll("\\s+","_");
String con=MainActivity.Contact.toString();
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	
new Remote_Data(getApplicationContext(),unm,con,ii).execute("");	


}
    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    
}

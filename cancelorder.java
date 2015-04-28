package com.example.digi_restaurateur;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;

public class cancelorder extends Activity {
Button btnYes;
Button btnNo;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
    
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cancelorder);
  
        btnYes=(Button)findViewById(R.id.button1);
        btnNo=(Button)findViewById(R.id.button2);
        
        btnYes.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v) 
   			{
   				// TODO Auto-generated method stub
   				
   				deleteorder();
   				//call delete constructor
   				int id=DatabaseHandler.o_otid;
   				new Remote_Data(getApplicationContext(),id).execute("");
   				Toast.makeText(cancelorder.this, "welcome to logout...",5).show();
   			 finish();
   			}
   		});
          		
        btnNo.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v) 
   			{
   				// TODO Auto-generated method stub
   				Intent ie=new Intent(cancelorder.this,order.class);
   				startActivity(ie);
   				Toast.makeText(cancelorder.this, "welcome to OrderAgain ...",5).show();
   			 finish();
   			}
   		});
        
    }

    public void deleteorder()
    {
    	DatabaseHandler db = new DatabaseHandler(getApplicationContext());
  			
			long sd=db.simple();
			Toast.makeText(cancelorder.this, "Orderdeleted..."+String.valueOf(sd),5).show();
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) 
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    
}



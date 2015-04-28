package com.example.digi_restaurateur;

import java.util.ArrayList;
import java.util.List;

import com.example.digi_restaurateur.AlertDialogRadio.AlertPositiveListener;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

public class order extends Activity 
{
	public static String tips="";
	private ListView lstListView1;
	public static Button btnCancel;
	public static int click=1;
	Button btnUpdate;
	Button btnConfirm;
	EditText tip;
	String[] menu;
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
    	
    	
        super.onCreate(savedInstanceState);
        setContentView(R.layout.order);
       
        lstListView1=(ListView) findViewById(R.id.listView1);
        btnUpdate=(Button)findViewById(R.id.button1);
        btnCancel=(Button)findViewById(R.id.button2);
        btnConfirm=(Button)findViewById(R.id.button3);
        
        tip=(EditText)findViewById(R.id.editText1);
        
        Loadorderdata();
        btnCancel.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v)
   			{
   				
   				if(click==2)
   			  { Toast.makeText(order.this,"Your Time Is Over.....Please Contact Manager....",Toast.LENGTH_SHORT).show();	
   				
   			  }
   				else
   				{
   				// TODO Auto-generated method stub
   	   				Intent i=new Intent(order.this,cancelorder.class);
   	   				startActivity(i);

   	   				Toast.makeText(order.this, "welcome to Cancel order...",5).show();
   	   			 finish();
   				}
   			}
   		});
          		

        btnUpdate.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v) 
   			{
   				// TODO Auto-generated method stub
   				Intent i=new Intent(order.this,menu.class);
   				startActivity(i);
   				Toast.makeText(order.this, "welcome to Update Menu...",5).show();
   			 finish();
   			}
   		});
          	
   			
        btnConfirm.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v) 
   			{
   				// TODO Auto-generated method stub
   				if(tip.length()==10==true)
   				{
   					Toast.makeText(order.this, "welcome to FinalConfirmOrder...",5).show();
   	   				tips="NO_TIPS";
   	   				
   	   				Intent i=new Intent(order.this,orderandbill.class);
   	   				startActivity(i);
   	   			 finish();
   				}
   				else
   				{
   				Toast.makeText(order.this, "welcome to FinalConfirmOrder...",5).show();
   				tips=tip.getText().toString().replaceAll("\\s+","_");
   				tips.replaceAll("\\s+","_");
   				Intent i=new Intent(order.this,orderandbill.class);
   				startActivity(i);
   			 finish();
   				}
   			}
   		});
        
     //start
    /*    	ArrayList<String> arr = new ArrayList<String>();
        	arr.add(getIntent().getStringExtra("hi").toString());
        	ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
            android.R.layout.simple_list_item_1, arr);
        	lstListView1.setAdapter(adapter);   
   		
        	Toast.makeText(order.this,""+arr,Toast.LENGTH_SHORT).show();	
   		*/
   	    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    private void Loadorderdata()
	{
	 


    	DatabaseHandler db = new DatabaseHandler(getApplicationContext());
		List<String> lables2 = db.getorderdata();
		//Toast.makeText(getBaseContext(),"You Selected-"+lables2, Toast.LENGTH_SHORT).show();
		ArrayAdapter<String> adapterr = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_1, lables2);
		lstListView1.setAdapter(adapterr);
       
	    
    }


	
}



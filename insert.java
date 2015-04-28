package com.example.digi_restaurateur;

import android.os.Bundle;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.view.Menu;
import java.util.List;


import android.widget.SimpleCursorAdapter;
import android.content.Context;
import android.content.pm.LabeledIntent;
import android.database.Cursor;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class insert extends Activity {
 //   Spinner spinner;
	
	EditText  pname1,price1,desc1,status1,cid1,one1;
    Button btnAdd,disp,submit;
  
   TextView t;
 ListView listView1,listView2;

 private SimpleCursorAdapter dataAdapter;
 
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.insert);
        
        cid1 = (EditText) findViewById(R.id.editText7);
        pname1 = (EditText) findViewById(R.id.editText1);
		 price1 = (EditText) findViewById(R.id.editText2);
		 desc1 = (EditText) findViewById(R.id.editText3);
		 status1 = (EditText) findViewById(R.id.editText4);		
		 one1 = (EditText) findViewById(R.id.editText5);
		 
		submit=(Button)findViewById(R.id.button1);
		disp=(Button)findViewById(R.id.button2);
		
		 submit.setOnClickListener(new View.OnClickListener() {
			 
	            @Override
	            public void onClick(View arg0) {
	               
	            	String one = one1.getText().toString();
	            	String cid = cid1.getText().toString();
	            	String pname = pname1.getText().toString();
		                String add = price1.getText().toString();
		                String con = desc1.getText().toString();
		                String cname = status1.getText().toString();
		               
		                
	                if (cname.trim().length() > 0) {
	                    DatabaseHandler db = new DatabaseHandler(getApplicationContext());
	                   long im=db.createTODOTAG(one,cid,pname,add,con,cname);
	                 
	                 //  long immv=db.createTag(one,one,cid,pname,add,con,cname,cname);
		                    
	                   

	                 //   Toast.makeText(getApplicationContext(), ""+im+"*"+immv,
	                   //         Toast.LENGTH_SHORT).show();
	                    // making input filed text to blank
	                    cid1.setText("");
	                    pname1.setText("");
	                   price1.setText("");
	                   desc1.setText("");
	                   status1.setText("");
	                 
	                   
	                   
	                    // Hiding the keyboard
	                    InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
	                    imm.hideSoftInputFromWindow(cid1.getWindowToken(), 0);
	                    imm.hideSoftInputFromWindow(pname1.getWindowToken(), 0);
	                    imm.hideSoftInputFromWindow(price1.getWindowToken(), 0);
	                    imm.hideSoftInputFromWindow(desc1.getWindowToken(), 0);
	                    imm.hideSoftInputFromWindow(status1.getWindowToken(), 0);
	                   
	                          
	                    
	                    
	                } 
	                else 
	                {
	                    Toast.makeText(getApplicationContext(), "veg",
	                            Toast.LENGTH_SHORT).show();
	                    
	                    DatabaseHandler db = new DatabaseHandler(getApplicationContext());
	                   
	                    long too=db.createToDo(cid,pname);
	                   
	                  //  long to=db.Ordr(cid,cid);
 		                
	                    Toast.makeText(getApplicationContext(),""+String.valueOf(too),  Toast.LENGTH_SHORT).show();
	      	           
		                   pname1.setText("");
		                   cid1.setText("");
	                    
	                }
	 
	            }
	        });
	 
		
		 //display2 toast ALL AND IN TXT
	        disp.setOnClickListener(new View.OnClickListener() {
				
				@Override
				public void onClick(View arg0) {
		
					DatabaseHandler db = new DatabaseHandler(getApplicationContext());
	
		Cursor c = (Cursor) db.getAllMenu3();
		
					if (c.moveToFirst())
					{
						do {
							DisplayContact(c);
						} while (c.moveToNext());
					}
					db.close();
				}
	 
				private void DisplayContact(Cursor c)
				{
					// TODO Auto-generated method stub
					/*Toast.makeText(getBaseContext(),"id " + c.getString(0)+
							"cid " + c.getString(1)+
							"\n" +"pname " + c.getString(2) + 
							"\n" +"price1: " + c.getString(3) +
							"\n" +"desc1" + c.getString(4) +
							"\n" +"status1" + c.getString(5),
							Toast.LENGTH_SHORT).show();
					*/
					 one1.setText(c.getString(0));
					 cid1.setText(c.getString(1));
					pname1.setText(c.getString(2));
	                   price1.setText(c.getString(3));
	                   desc1.setText(c.getString(4));
	                   status1.setText(c.getString(5));
	    				
				}
				
				
			});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

}

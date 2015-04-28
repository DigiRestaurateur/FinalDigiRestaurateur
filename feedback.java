package com.example.digi_restaurateur;

import java.util.List;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class feedback extends Activity 
{
	
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
    	
    	Button btnFeedback;
    	final EditText etxFeedback;
    	final TextView txtUserName;
		final TextView txtContact;
    	
        super.onCreate(savedInstanceState);
        setContentView(R.layout.feedback);
                        
       
        btnFeedback=(Button)findViewById(R.id.button1);
        etxFeedback=(EditText)findViewById(R.id.editText3);
        txtUserName=(TextView)findViewById(R.id.textView4);
        txtContact=(TextView)findViewById(R.id.textView6);
       
        txtUserName.setText(""+MainActivity.UserName.toString());
		txtContact.setText(""+MainActivity.Contact.toString());
		
        
        btnFeedback.setOnClickListener(new OnClickListener() 
        {
			
			@Override
			public void onClick(View v) 
			{
				// TODO Auto-generated method stub
			
						String strUserName=txtUserName.getText().toString();
						String strContact=txtContact.getText().toString();
						new Remote_Data(getApplicationContext(),strUserName,strContact,etxFeedback).execute("");
						Toast.makeText(feedback.this, "Welcome to Feedback"+etxFeedback.getText().toString(),Toast.LENGTH_LONG).show();
						etxFeedback.setText("");
						finish();
			}
		});
     
        }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) 
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    
}



package com.example.digi_restaurateur;


import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Toast;

public class gallary extends Activity  {

	 ArrayAdapter<String> adapter1;
	 ListView mylistview;
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
  //  	Button btnBack;
    	
        super.onCreate(savedInstanceState);
        setContentView(R.layout.extra);
        
  /*      btnBack=(Button)findViewById(R.id.button2);
        
        btnBack.setOnClickListener(new OnClickListener()
        {
			
			@Override
			public void onClick(View v)
			{
				// TODO Auto-generated method stub
				Intent i=new Intent(gallary.this,homepanel.class);
				startActivity(i);
				Toast.makeText(gallary.this, "Back to menu",5).show();

			}
		});*/
        
       // spinnerDropDown =(Spinner)findViewById(R.id.spinner1);
     
        
       
  
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    
}



package com.example.digi_restaurateur;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;

public class callaries extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
    	Button btnBack;
    	
        super.onCreate(savedInstanceState);
        setContentView(R.layout.callaries);
        
        btnBack=(Button)findViewById(R.id.button2);
        
        btnBack.setOnClickListener(new OnClickListener() 
        {
			
			@Override
			public void onClick(View v) 
			{
				// TODO Auto-generated method stub
				Intent i=new Intent(callaries.this,homepanel.class);
				startActivity(i);
				Toast.makeText(callaries.this, "Back to menu",5).show();

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



package com.example.digi_restaurateur;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;

public class logout extends Activity {
Button logout;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
    	
        super.onCreate(savedInstanceState);
        setContentView(R.layout.logout);
        logout=(Button)findViewById(R.id.button1);
        
        logout.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View arg0) {
				// TODO Auto-generated method stub

		        deleteorder(); 			
		        Intent i=new Intent(logout.this,homepanel.class);
   				startActivity(i);
   			 finish();
   				
			}
		});
        }

    public void deleteorder()
    {
    	DatabaseHandler db = new DatabaseHandler(getApplicationContext());
  			
			long sd=db.simple();
			Toast.makeText(logout.this, "Orderdeleted..."+String.valueOf(sd),5).show();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    
}



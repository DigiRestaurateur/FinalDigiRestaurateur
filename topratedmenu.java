package com.example.digi_restaurateur;

import java.util.List;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class topratedmenu extends Activity 
{
	Button btnBack;
	ListView lstTopMenu;
    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {    	
    	
        super.onCreate(savedInstanceState);
        setContentView(R.layout.topratedmenu);
        
       
        lstTopMenu=(ListView)findViewById(R.id.listView1);
       
        loadtopmenu();
        
               
   }

    private void loadtopmenu() 
    {
    	
    		DatabaseHandler db = new DatabaseHandler(getApplicationContext());
  	        List<String> lables1 = db.topRatedMenu();
  	        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,R.layout.list2color, lables1);
  	        lstTopMenu.setAdapter(adapter);
  	 
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) 
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
   
    
}

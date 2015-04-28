package com.example.digi_restaurateur;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;
import org.json.JSONObject;

import com.example.digi_restaurateur.AlertDialogRadio.AlertPositiveListener;


import android.os.Bundle;
import android.app.Activity;
import android.app.FragmentManager;
import android.content.Intent;
import android.database.Cursor;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;

public class menu extends Activity implements AlertPositiveListener
{	   public static int flag=0;

	int position=0;
	Spinner tableId;
  public static String pitem="",tableNo="";
  public char c = 0;
  private ListView lstListView1,lstListView2;
  public static String selectedItem="",psortv="";
  public int quantity;
  public int val;
  private  ArrayList<String> Array1 = new ArrayList<String>();// to store list of selected views
  private  ArrayList<Integer> PositionArray = new ArrayList<Integer>();// to store list of selected positions
	public static long l=0;
  @Override
    protected void onCreate(Bundle savedInstanceState) 
  	{
    	Button btnOrder,psortbtn;
    	 
        super.onCreate(savedInstanceState);
        setContentView(R.layout.menu);
	//	Toast.makeText(menu.this, "Welcome to Callaries"+Remote_Data.otbid,5).show();
       // tableId=(Spinner)findViewById(R.id.spinner1);
		
        btnOrder=(Button)findViewById(R.id.button7);
        lstListView1=(ListView) findViewById(R.id.listView1);
        lstListView2=(ListView) findViewById(R.id.listView2);        
        lstListView2.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);
        psortbtn=(Button)findViewById(R.id.button8);
        LoadSpinnerData();

 
        btnOrder.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v) 
   			{
   				// TODO Auto-generated method stub
   				Intent i=new Intent(menu.this,order.class);   				
   				i.putExtra("hi", ""+Array1);   				
   				startActivityForResult(i, 1);
   				
   				Toast.makeText(menu.this, "welcome to OrderDetails",5).show();
   			 finish();
   				  			}
   		});
        
        psortbtn.setOnClickListener(new OnClickListener() 
        {
   			
   			@Override
   			public void onClick(View v) 
   			{
   				psort(psortv);
   			}
   		});

   //maza code    
    
       lstListView1.setOnItemClickListener(new OnItemClickListener()
       {

   		@Override
   			public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,long arg3) 
   		{
   			// TODO Auto-generated method stub
   			
   			DatabaseHandler db = new DatabaseHandler(getApplicationContext());
   			String item = ((TextView)arg1).getText().toString();
   	//		psortv=Integer.parseInt(item);
           psortv=item.toString();
             p(item);
            Toast.makeText(getBaseContext(),"You are selected-"+item, Toast.LENGTH_SHORT).show();  
            
   //now call second select cat php file     
            //String sd=db.simple();     pitem=item;
 // new Remote_Data(getApplicationContext(),pitem,"").execute("admin");//for allcategory          
            //Toast.makeText(getBaseContext(),""+sd, Toast.LENGTH_SHORT).show();
              		}
       	   
   	});
   
       lstListView2.setOnItemClickListener(new OnItemClickListener() 
       {

      		@Override
      		public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,long arg3) 
      		{	
      			// TODO Auto-generated method stub
      			DatabaseHandler db = new DatabaseHandler(getApplicationContext());
      			String item = ((TextView)arg1).getText().toString();
      			selectedItem=item.toString();
      			val=arg2;
      				lstListView2.setItemChecked(val, false); 
    		
      			  String co="";
          	
      	    	  
          		  	flag=0;
          			String fi=selectedItem.substring(0,3);
          			for(int i = 0; i < fi.length(); i++)
          		  	{
          		  		c = selectedItem.charAt(i);
          		  		int ascii = (int) c;
          		  		
          		  	if(ascii>=48&&ascii<=57)
          		  		{
          		  	String m = Character.toString(c);
          		  		co=co.concat(m);
          		  	
          		  	} 
          		  }
          		 
          			int g=db.orderCheck(co);
          			if(g==1)
          		{

                		  //---------------
                lstListView2.setItemChecked(val, false); 
                	
                	    		
                		long cii =Integer.parseInt(co);
                		DatabaseHandler db1 = new DatabaseHandler(getApplicationContext());
              							    	    	  
            db1.orderdelete(cii);
            	 
          	}
          	      	else
          		{

      	   FragmentManager manager = getFragmentManager();
				 
	            /* Instantiating the DialogFragment class */
	            AlertDialogRadio alert = new AlertDialogRadio();

	            /** Creating a bundle object to store the selected item's index */
	           Bundle b  = new Bundle();

	            /** Storing the selected item's index in the bundle object */
			  b.putInt("position", position);

	            /** Setting the bundle object to the dialog fragment object */
			alert.setArguments(b);

	            /** Creating the dialog fragment object, which will in turn open the alert dialog window */
		      alert.show(manager, "alert_dialog_radio");
      		
          		}
      		}
      	});
       
      
       
    }
	
	public void p(String item)
	{
		
				DatabaseHandler db = new DatabaseHandler(getApplicationContext());
				List<String> lables2 = db.perticular(item);
				//Toast.makeText(getBaseContext(),"You Selected-"+lables2, Toast.LENGTH_SHORT).show();
				ArrayAdapter<String> adapterr = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_multiple_choice, lables2);
				lstListView2.setAdapter(adapterr);

   }


	public void psort(String psortv)
	{
		
				DatabaseHandler db = new DatabaseHandler(getApplicationContext());
				List<String> lables2 = db.perticularsort(psortv);
				//Toast.makeText(getBaseContext(),"You Selected-"+lables2, Toast.LENGTH_SHORT).show();
				ArrayAdapter<String> adapterrr = new ArrayAdapter<String>(this,
						android.R.layout.simple_list_item_multiple_choice, lables2);
						lstListView2.setAdapter(adapterrr);

   }	

	private void LoadSpinnerData()
	{
	
		 	DatabaseHandler db = new DatabaseHandler(getApplicationContext());
	        List<String> lables1 = db.getAllcat();
	        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
	        R.layout.list1color, lables1);
	        lstListView1.setAdapter(adapter);        
	    
    }
	
	
   
    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

	@Override
	public void onPositiveClick(int position) {
		// TODO Auto-generated method stub
		 this.position = position;
		 
	        /** Getting the reference of the textview from the main layout */
	     //   Toast.makeText(menu.this,"good"+Android.code[this.position],5).show();
	 
	      String codes=Android.code[this.position];
	      quantity=Integer.parseInt(codes);
	    //  Toast.makeText(menu.this,"code is"+quantity,5).show();
	      
	      
	      
	      
	      //---------------
	      String co="";
		  	
		  	String fi=selectedItem.substring(0,3);
			for(int i = 0; i < fi.length(); i++)
		  	{
		  		c = selectedItem.charAt(i);
		  		int ascii = (int) c;
		  		
		  	if(ascii>=48&&ascii<=57)
		  		{
		  		String m = Character.toString(c);
		  		co=co.concat(m);
		  	
		  		} 
		  	}
	      
	    	 // lstListView2.setItemChecked(val, false);
	    	//	lstListView2.setItemChecked(val, false);
	    	 
  			String f=MainActivity.tbl.toString();
  			long ci =Integer.parseInt(co);
		  		
  			DatabaseHandler db1 = new DatabaseHandler(getApplicationContext());
  			String rslt=db1.ordering(f,ci,quantity);

  			
  		//	Toast.makeText(menu.this,"fi"+ci+"m"+rslt,Toast.LENGTH_SHORT).show();
  			
  			 lstListView2.setItemChecked(val, true); 
  		     
	}
	}


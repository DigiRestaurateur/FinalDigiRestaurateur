package com.example.digi_restaurateur;

import java.util.ArrayList;
import java.util.List;
 
import android.R.string;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.database.sqlite.SQLiteStatement;
 
public class DatabaseHandler extends SQLiteOpenHelper {
    // Database Version
	public   String selectQuery="";
  public  String x="";
  public String im="",om="";
  public String rslt="";
 public String rsltd="";
  	private static final int DATABASE_VERSION = 1;
  	public static int o_otid;
    // Database Name
    private static final String DATABASE_NAME = "Digi_Restaurator";
 
    // Labels table name
    
    private static final String TABLE_TODO = "CATEGORYS";
	private static final String TABLE_TAG = "MYORDERS";
	private static final String TABLE_TODO_TAG = "MENU";



    // cat Table Columns  names
	 private static final String CAT_ID = "cid";
	 private static final String CAT_NAME = "cname";
    
   
    
    // Labels Table Columns names
    private static final String KEY_ID = "itemid";
    private static final String KEY_CID= "ctid"; 
    private static final String KEY_NAME = "iname";
    private static final String KEY_PRICE = "iprice";
    private static final String KEY_DESC = "idesc";
    private static final String KEY_STATUS = "istatus";
    
   
  //
    private static final String O_OID= "otids";
    private static final String O_TID = "oids";
    private static final String O_OITID= "cid"; 
    private static final String O_ITEMS= "oitems";
    private static final String O_PRICE= "iprice";
    private static final String O_QTY= "oqty";
    private static final String O_OTOTAL = "ototal";
    private static final String O_STATUS = "ostatus";
    
    
    private static final String CREATE_TABLE_TODO = "CREATE TABLE "
			+ TABLE_TODO + "(" + CAT_ID	+ " INTEGER PRIMARY KEY," + CAT_NAME + " TEXT" + ")";

	private static final String CREATE_TABLE_TAG = "CREATE TABLE " + TABLE_TAG
			+ "(" + O_OID + " INTEGER," + O_TID + " TEXT,"
			+ O_OITID + " INTEGER,"+ O_ITEMS + " TEXT,"+ O_PRICE + " INTEGER,"+ O_QTY + " INTEGER,"+ O_OTOTAL + " INTEGER,"+ O_STATUS + " TEXT" + ")";

	
	 
	
	// todo_tag table create statement
	private static final String CREATE_TABLE_TODO_TAG = "CREATE TABLE "
			+ TABLE_TODO_TAG + "(" + KEY_ID + " INTEGER PRIMARY KEY,"
			+ KEY_CID + " INTEGER,"+ KEY_NAME + " TEXT,"+ KEY_PRICE + " INTEGER,"+ KEY_DESC + " TEXT," + KEY_STATUS + " TEXT" + ")";


  
    public DatabaseHandler(Context context) 
    {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }
 
    // Creating Tables
    @Override
    public void onCreate(SQLiteDatabase db) 
    {
    	db.execSQL(CREATE_TABLE_TODO);
		db.execSQL(CREATE_TABLE_TAG);
		db.execSQL(CREATE_TABLE_TODO_TAG);
	
    }
 
    // Upgrading database
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
    	db.execSQL("DROP TABLE IF EXISTS " + TABLE_TODO);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_TAG);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_TODO_TAG);

        // Create tables again
        onCreate(db);
    }
    
    public long createToDo(String label1,String label2) {
		SQLiteDatabase db = this.getWritableDatabase();
		int i=0;
		try
		{
				
		ContentValues values = new ContentValues();
	//	values.put(KEY_ID,label);
		values.put(CAT_ID, label1);
		values.put(CAT_NAME,label2);
		// insert row
		long todO_TID = db.insert(TABLE_TODO, null, values);
		
    }
    catch(Exception e){
  	  				e.printStackTrace();
  	  				i=5;
    			}
	
	db.close();
	return i;
	
}
    public Cursor getAllMenu1()
	{	SQLiteDatabase db = this.getReadableDatabase();
		return db.query(TABLE_TODO, new String[] {CAT_ID,
				CAT_NAME},null, null, null, null, null);
	}

	public long createTag(String label1,String label2,String label3,String label4,String label5,String label6,String label7,String label8) {
		SQLiteDatabase db = this.getWritableDatabase();

		int i=0;
		try
		{	ContentValues values = new ContentValues();		
			//values.put(KEY_ID, label);
			values.put(O_OID, label1);
			values.put(O_TID, label2);
			values.put(O_OITID, label3);
			values.put(O_ITEMS, label4);
			values.put(O_PRICE, label5);
			values.put(O_QTY, label6);
			values.put(O_OTOTAL, label7);
			values.put(O_STATUS, label8);
			// insert row
			long todO_TID1 = db.insert(TABLE_TAG, null, values);

    }
		catch(Exception e){
  	  				e.printStackTrace();
  	  				i=5;
    			}
	
	db.close();
	return i;
	}
	 public Cursor getAllMenu2()
		{	SQLiteDatabase db = this.getReadableDatabase();
			return db.query(TABLE_TAG, new String[] {O_OID,O_TID,O_OITID,O_ITEMS,O_PRICE,O_QTY,O_OTOTAL,
					O_STATUS},null, null, null, null, null);
		}

	public long createTODOTAG(String one,String ctid,String iname,String price,String desc,String status) {
		SQLiteDatabase db = this.getWritableDatabase();
		
		 int i=0;
	      try{
	    	  ContentValues values = new ContentValues();		
	      
			//values.put(KEY_ID, label);
			values.put(KEY_ID, one);
			values.put(KEY_CID, ctid);
			values.put(KEY_NAME, iname);
			values.put(KEY_PRICE, price);
			values.put(KEY_DESC, desc);
			values.put(KEY_STATUS, status);
			// insert row
			long todO_TID1 = db.insert(TABLE_TODO_TAG, null, values);

	      }
	      catch(Exception e){
	    	  				e.printStackTrace();
	    	  				i=5;
	      			}
		
		db.close();
		return i;
	}

	 public Cursor getAllMenu3()
		{	SQLiteDatabase db = this.getReadableDatabase();
			return db.query(TABLE_TODO_TAG, new String[] {KEY_ID,KEY_CID,KEY_NAME,KEY_PRICE,KEY_DESC,KEY_STATUS},null, null, null, null, null);
		}
    /**
     * Inserting new lable into lables table
     * */
    
    //MYORDERS
	
    public String ordering(String tableId,long itemId,long quantity)
    {
    	long itid=0;
    	String S="Available";
   	 	String otoid="";
		String otid="";
   	 	String octid="";
   	 	String oitems="";
   	 	String oprice="";
   	 	String oqty="1";
   	 	String odesc="";
   	 	String ostatus="";
   		List<String> plabels = new ArrayList<String>();
   		SQLiteDatabase db = this.getReadableDatabase();
   		SQLiteDatabase db1 = this.getReadableDatabase();
   		String plabel="";
   		
   	String ct = null;
   		try{
   			String selectQuery ="select * from MENU where itemid=" +itemId;						
   		    Cursor cursor = db.rawQuery(selectQuery, null);
   		
   	if (cursor.moveToFirst())
   	{
   	 do 
   	 {
   	     otoid=tableId.toString();
   	     otid=cursor.getString(0);
   	     octid=cursor.getString(1);
   	     oitems=cursor.getString(2).replace(" ","_");
   	    oprice=cursor.getString(3);
   	    oqty="1";
   	    odesc=cursor.getString(4);
   	    ostatus=cursor.getString(5);
   	 
   	  rslt=cursor.getString(0)+cursor.getString(1)+cursor.getString(2).replace(" ","_")+cursor.getString(3)+cursor.getString(4)+cursor.getString(5);
  	   
   	 } while (cursor.moveToNext());
   	}
   	cursor.close();
   	}
    
   	catch(Exception e)
   	{
   		rslt=""+e;
   	}

   			
   	//	String query ="select * from MENU where itemid="+ itemId;
   		String query ="select * from MYORDERS where oids='"+ itemId + "'";
   	  
   	    	Cursor cursor1 = db1.rawQuery(query, null);
   		
   		if (cursor1.moveToFirst())
   		 {
   	     do 
   	     	{
   	    	 String go=cursor1.getString(1);
   	         
   	         itid=Long.parseLong(go);
   	     	} while (cursor1.moveToNext());
   		 }
   		else
   		{
   			itid=123456;   			
   		}
   		cursor1.close();
   		
   		//itid="61";
   		if(itid==itemId)
   		{x="updated";  
  		
   		String total=String.valueOf(quantity);
		int ototal=Integer.parseInt(total) * Integer.parseInt(oprice);
	  	     
		
  		updateOrder(tableId,otid,octid,oitems,oprice,quantity,ototal,ostatus);
   		}
   		else
   		{
   			
   		SQLiteDatabase db2 = this.getWritableDatabase();
   		try
   			{	
   			String total=String.valueOf(quantity);
   			
   			String pending="Pending";
   			int ototal=Integer.parseInt(total)*Integer.parseInt(oprice);
   					ContentValues values = new ContentValues();	

   			       
   					
   					
   					
   		    		
   	            
		// otoid,otid,octid,oitems,oprice,oqty,odesc,ostatus	
			values.put(O_OID, o_otid);
			values.put(O_TID, tableId);
			values.put(O_OITID, itemId);
			values.put(O_ITEMS, oitems);
			values.put(O_PRICE, oprice);
			values.put(O_QTY, quantity);
			values.put(O_OTOTAL, ototal);
			values.put(O_STATUS, pending);
			// insert row
			long todO_TID1 = db.insert(TABLE_TAG, null, values);
			 x="inserted";
    	}
   					catch(Exception e){
  	  				e.printStackTrace();
  	  				x=""+e;
    					}
   		}
   		return x+rslt+")"+itemId+"("+itid+")";
    }
    	
  
    public boolean updateOrder(String tableId,String otid,String octid,String oitems,String oprice,long quantity,int ototal,String ostatus)
	  	{
			SQLiteDatabase db3 = this.getReadableDatabase();
	  		ContentValues args = new ContentValues();
	  		args.put(O_OID, tableId);
	  	    args.put(O_TID, otid);
	  		args.put(O_OITID, octid);
	  		args.put(O_ITEMS, oitems);
	  		args.put(O_PRICE, oprice);
	  		args.put(O_QTY, quantity);
	  		args.put(O_OTOTAL, ototal);
			args.put(O_STATUS, ostatus);
			
	  	    return db3.update(TABLE_TAG, args, O_TID + "=" + otid, null) > 0;
	  	}

    
  
   // Leftboxcat
    public List<String> getAllcat()
    {
        List<String> labels = new ArrayList<String>();
 
        // Select All Query
        String selectQuery = "select * from CATEGORYS";
 
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);
 
        // looping through all rows and adding to list
        if (cursor.moveToFirst()) 
        {
            do 
            {
            	labels.add(cursor.getString(1));               
            } while (cursor.moveToNext());
        }
 
        // closing connection
        cursor.close();
        db.close(); 
        // returning lables
        return labels;
    }
    
  //all MENU
    
 	 public List<String> perticular(String item)
 	 {String spacing="   ";
 	 String rs="Rs.";
 		 	String S="Available";
    		List<String> plabels = new ArrayList<String>();
    		SQLiteDatabase db = this.getReadableDatabase();
    		String plabel="";
    try{
    	String catq ="select * from CATEGORYS where cname='"+ item + "' ";
    	Cursor cursor = db.rawQuery(catq, null);
   		
   	 if (cursor.moveToFirst())
   	 {
         do 
         {
             plabel=cursor.getString(0);//2
            
         } while (cursor.moveToNext());
     }
   	cursor.close();
   	
	String selectQuery ="select * from MENU where ctid =" + plabel +" ORDER BY iname asc" ;// +"istatus ='Available'";
	//String selectQuery ="select * from MENU where ctid =" + item + "istatus ='Available'";

        Cursor c = db.rawQuery(selectQuery, null);
 
        // looping through all rows and adding to list
        if (c.moveToFirst())
        {
            do 
            {	if(c.getString(5).equals("Available"))
            		{
            	plabels.add(c.getString(0)+spacing+c.getString(2)+spacing+rs+c.getString(3)+spacing+c.getString(4));
            		}
            	else
            	{
            	
            	}
                
            } while (c.moveToNext());
        }
 
        // closing connection
        c.close();
        db.close();
 
        // returning lables
    }
    catch(Exception e)
    {
    
    }
        return plabels;
    }
 	
 	 
 	 
 	 
 	 //
     
  	 public List<String> perticularsort(String item)
  	 {String spacing="   ";
  	 String rs="Rs.";
  		 	String S="Available";
     		List<String> plabels = new ArrayList<String>();
     		SQLiteDatabase db = this.getReadableDatabase();
     		String plabel="";
     try{
     	String catq ="select * from CATEGORYS where cname='"+ item + "' ";
     	Cursor cursor = db.rawQuery(catq, null);
    		
    	 if (cursor.moveToFirst())
    	 {
          do 
          {
              plabel=cursor.getString(0);//2
             
          } while (cursor.moveToNext());
      }
    	cursor.close();
    	//SELECT * FROM digidatabase.ordertable WHERE table_id=6 order by order_itid asc 	
 	String selectQuery ="select * from MENU where ctid =" + plabel +" ORDER BY iprice asc" ;// +"istatus ='Available'";
 	//String selectQuery ="select * from MENU where ctid =" + item + "istatus ='Available'";

         Cursor c = db.rawQuery(selectQuery, null);
  
         // looping through all rows and adding to list
         if (c.moveToFirst())
         {
             do 
             {	if(c.getString(5).equals("Available"))
             		{
             	plabels.add(c.getString(0)+spacing+c.getString(2)+spacing+rs+c.getString(3)+spacing+c.getString(4));
             		}
             	else
             	{
             	
             	}
                 
             } while (c.moveToNext());
         }
  
         // closing connection
         c.close();
         db.close();
  
         // returning lables
     }
     catch(Exception e)
     {
     
     }
         return plabels;
     }
  	
    //Alldata on toast
    public List<String> getAllLabels()
    {
        List<String> labels = new ArrayList<String>();
 
        // Select All Query
        String selectQuery = "SELECT  * FROM " + TABLE_TODO_TAG;
 
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);
 
        // looping through all rows and adding to list
        if (cursor.moveToFirst()) 
        {
            do 
            {
            	labels.add(cursor.getString(0)+cursor.getString(1)+cursor.getString(2)+cursor.getString(3)+cursor.getString(4)+cursor.getString(5));
               
            } while (cursor.moveToNext());
        }
 
        // closing connection
        cursor.close();
        db.close();
 
        // returning lables
        return labels;
    }
    
    
    
    //getall toast display skip
    public Cursor getAllMenu()
	{	SQLiteDatabase db = this.getReadableDatabase();
		return db.query(TABLE_TODO_TAG, new String[] {KEY_ID,KEY_CID,
  				KEY_NAME,KEY_PRICE,KEY_DESC,KEY_STATUS},null, null, null, null, null);
	}
    
 	
    
    //topMENU
  	
    public List<String> topRatedMenu()
    {
        List<String> plabels = new ArrayList<String>();
       // String selectQuery ="select  itemid,iname,istatus from MENU LIMIT 5";//MYORDERS by column_name
        String selectQuery ="select * from MENU LIMIT 5";//MYORDERS by column_name
      //  String selectQuery ="select * from MYORDERS";//MYORDERS by column_name
              
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);
 
        // looping through all rows and adding to list
        if (cursor.moveToFirst()) 
        {
            do 
            {
                plabels.add(cursor.getString(0)+"  "+cursor.getString(2));
            } while (cursor.moveToNext());
        }
 
        // closing connection
        cursor.close();
        db.close();
 
        // returning lables
        return plabels;
    }
    
    
    public int categoryCheck(String cat_id) throws SQLException
  	{	SQLiteDatabase db = this.getReadableDatabase();

      int i = 0;
      try
  	    {
  	        Cursor c = null;
  	        c = db.rawQuery("select * from " + TABLE_TODO +"where cid ='"+ cat_id+ "'", null);
  	   
  	        c.moveToFirst();
  	        i = c.getCount(); 
  	        //c.close();   	       
  	    }
  	    catch(Exception e)
  	    {
  	        e.printStackTrace();
  	        i=5;
  	    }
  	    return i;
  	}
    
    public int orderCheck(String itemid) throws SQLException
  	{
    	SQLiteDatabase db = this.getReadableDatabase();

      int i = 0;
      try
  	    { 	 Cursor c = null;
  	       	c = db.rawQuery("select * from MYORDERS where cid ='"+ itemid+ "'", null);  	   
  	        c.moveToFirst();
  	        i = c.getCount(); 
  	        //c.close();   	       
  	    }
  	    catch(Exception e)
  	    {
  	        e.printStackTrace();
  	        i=5;
  	    }
  	    return i;
  	}
    
    public int menuCheck(String itemid) throws SQLException
  	{
    	SQLiteDatabase db = this.getReadableDatabase();

      int i = 0;
      try
  	    { 	 Cursor c = null;
  	       	c = db.rawQuery("select * from MENU where itemid ='"+ itemid+ "'", null);  	   
  	        c.moveToFirst();
  	        i = c.getCount(); 
  	        //c.close();   	       
  	    }
  	    catch(Exception e)
  	    {
  	        e.printStackTrace();
  	        i=5;
  	    }
  	    return i;
  	}
    
    //UPDATE
    
	//---updates a contact---
  	public boolean updateMenu(long one,String ctid,String iname,String price,String desc,String status)
  	{
  		SQLiteDatabase db = this.getReadableDatabase();
  		ContentValues args = new ContentValues();
  		
  		args.put(KEY_CID, ctid);
  		args.put(KEY_NAME, iname);
  		args.put(KEY_PRICE, price);
  		args.put(KEY_DESC, desc);
  	    args.put(KEY_STATUS, status);
  	     
  	    return db.update(TABLE_TODO_TAG, args, KEY_ID + "=" + one, null) > 0;
  	}
  	


//UPDATE

/*
ordertable

order_id
table_id
_item
_quantity
__price
_desc
_status
*/

 
    public List<String> getAllcatt()
    {
        List<String> labels = new ArrayList<String>();
 
        // Select All Query
        String selectQuery = "SELECT  * FROM CATEGORYS";// + TABLE_TODO;
 
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);
 
        // looping through all rows and adding to list
        if (cursor.moveToFirst()) 
        {
            do 
            {
            	labels.add(cursor.getString(1));               
            } while (cursor.moveToNext());
        }
 
        // closing connection
        cursor.close();
        db.close(); 
        // returning lables
        return labels;
    }

    
    public long or(String itemId)throws SQLException
    { SQLiteDatabase db1 = this.getReadableDatabase();
    
   	 	 long itid;
   	      //  String	catu ="SELECT * FROM "+TABLE_TAG;
    	String query ="select * from MYORDERS where oids='"+ itemId + "'";
     	  
	    	Cursor cursor1 = db1.rawQuery(query, null);
		
		if (cursor1.moveToFirst())
		 {
	     do 
	     	{
	    	 String go=cursor1.getString(1);
	         
	         itid=Long.parseLong(go);
	     	} while (cursor1.moveToNext());
		 }
		else
		{
			itid=123456;   			
		}
		cursor1.close();
    return itid;
    }


   
    
    public long simple()
    {	
    	
    	SQLiteDatabase db = this.getReadableDatabase();   
    	
    		return db.delete(TABLE_TAG, null, null);
    	
    }
   
    
    public long orderdelete(long otid)
    {	
    	
    	SQLiteDatabase db = this.getReadableDatabase();   
    	
    		
    	return db.delete(TABLE_TAG, O_OITID + "=" + otid,null);
    }
    public List<String> getorderdata()
    {
        List<String> labels = new ArrayList<String>();
        String spacing="  ";
        String rs="Rs.";
    	SQLiteDatabase db = this.getReadableDatabase();
    	String selectQuery ="select * from MYORDERS";
    	//String selectQuery ="select * from MENU where ctid =" + item + "istatus ='Available'";
String extra="";
            Cursor c = db.rawQuery(selectQuery, null);
     
            // looping through all rows and adding to list
            if (c.moveToFirst())
            {	    do 
                {
                    labels.add(c.getString(0)+spacing+spacing+c.getString(1)+spacing+spacing+c.getString(2)+spacing+spacing+c.getString(3)+spacing+spacing+rs+c.getString(4)+spacing+spacing+c.getString(5)+spacing+spacing+c.getString(6));
                } while (c.moveToNext());
            }
            
           
     

        // closing connection
        c.close();
        db.close(); 
        // returning lables
        return labels;
    }

//==============
    //bill
    
    
  
      public int billingData() {

    		SQLiteDatabase db = this.getReadableDatabase();
    final SQLiteStatement stmt = db
            .compileStatement("SELECT SUM(ototal) FROM MYORDERS");

    // Cast as appropriate
    return (int) stmt.simpleQueryForLong();
}

     
    
    
    
    
    
    
    
    
    
    
    
}


//  ORDER_TIDORDER_IDORDER_CTIDORDER_ITEMSORDER_PRICEORDER_QTYORDER_DESMYORDERS_STATUS
   

package com.example.testsend;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;

import android.app.Activity;
import android.content.Context;
import android.hardware.Sensor;
import android.hardware.SensorManager;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.os.Bundle;
import android.widget.TextView;
//import android.widget.Toast;

public class MainActivity extends Activity implements SensorEventListener {
	
	int n = 0;
	
	public TextView xyView;
	public TextView xzView;
	public TextView zyView;
	
	private SensorManager msensorManager;
	
    private float[] rotationMatrix;
    private float[] accelData;
    private float[] magnetData;
	private float[] OrientationData;
	
	private String x;
	private String y;
	private String z;	
	 
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        msensorManager = (SensorManager)getSystemService(Context.SENSOR_SERVICE);
        
        rotationMatrix = new float[16];
        accelData = new float[3];
        magnetData = new float[3];
        OrientationData = new float[3]; 
        
        xyView = (TextView) findViewById(R.id.xyValue);  
        xzView = (TextView) findViewById(R.id.xzValue);
        zyView = (TextView) findViewById(R.id.zyValue);  
    }
    
    @Override
    protected void onResume() {
    	super.onResume();
    	msensorManager.registerListener(this, msensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER), SensorManager.SENSOR_DELAY_UI );
    	msensorManager.registerListener(this, msensorManager.getDefaultSensor(Sensor.TYPE_MAGNETIC_FIELD), SensorManager.SENSOR_DELAY_UI );
    }
    
    @Override
    protected void onPause() {
        super.onPause();
        msensorManager.unregisterListener(this);
    }
    
    public void onAccuracyChanged(Sensor sensor, int accuracy) {
		// TODO Auto-generated method stub
		
	}

	public void onSensorChanged(SensorEvent event) {
		loadNewSensorData(event);
        SensorManager.getRotationMatrix(rotationMatrix, null, accelData, magnetData);
        SensorManager.getOrientation (rotationMatrix, OrientationData);
        
        if((xyView==null)||(xzView==null)||(zyView==null)){
        	xyView = (TextView) findViewById(R.id.xyValue); 
            xzView = (TextView) findViewById(R.id.xzValue);
            zyView = (TextView) findViewById(R.id.zyValue);  
        }
        
        xyView.setText(String.valueOf(Math.round(Math.toDegrees(OrientationData[1]))));
        xzView.setText(String.valueOf(Math.round(Math.toDegrees(OrientationData[2]))));
        zyView.setText(String.valueOf(Math.round(Math.toDegrees(OrientationData[0]))));
        
        x = String.valueOf(Math.round(Math.toDegrees(OrientationData[1])));
        y = String.valueOf(Math.round(Math.toDegrees(OrientationData[2])));
        z = String.valueOf(Math.round(Math.toDegrees(OrientationData[0])));
        
        n++;
        
        if (n == 10)
        {
        	sendData(x,y,z);
        	n = 0;
        }
	}
	
	private void loadNewSensorData(SensorEvent event) {
        
        final int type = event.sensor.getType();
       
        if (type == Sensor.TYPE_ACCELEROMETER) {
                accelData = event.values.clone();
        }
       
        if (type == Sensor.TYPE_MAGNETIC_FIELD) {
                magnetData = event.values.clone();
        }
	}
	
	private void sendData(String x, String y, String z)
	{
		//BufferedReader bufferedReader = null;
        HttpClient httpClient = new DefaultHttpClient();
        HttpPost request = new HttpPost("http://xpss.servebeer.com:25565/remotem/Home/SetData");
        List<NameValuePair> postParameters = new ArrayList<NameValuePair>();
        postParameters.add(new BasicNameValuePair("X", x));
        postParameters.add(new BasicNameValuePair("Y", y));
        postParameters.add(new BasicNameValuePair("Z", z));
        
        
        try 
        {
        	UrlEncodedFormEntity entity = new UrlEncodedFormEntity(postParameters);
        	request.setEntity(entity);
            HttpResponse response= httpClient.execute(request);

            //bufferedReader = new BufferedReader(
            		//new InputStreamReader(response.getEntity().getContent()));
            //StringBuffer stringBuffer = new StringBuffer("");
            //String line = "";
            //String LineSeparator = System.getProperty("line.separator");
            //while ((line = bufferedReader.readLine()) != null) {
            	//stringBuffer.append(line + LineSeparator); 
            //}
            //bufferedReader.close();
   
            //Toast.makeText(MainActivity.this, 
            //		"Finished", 
            //		Toast.LENGTH_LONG).show();
   
        }
        //catch (ClientProtocolException e) 
        //{
        //	e.printStackTrace();
        //	Toast.makeText(MainActivity.this, 
        //			e.toString(), 
        //			Toast.LENGTH_LONG).show();
        //}
        catch (IOException e) 
        {
        //	e.printStackTrace();
        //	Toast.makeText(MainActivity.this, 
        //			e.toString(), 
        //			Toast.LENGTH_LONG).show();
        }
        //finally
        //{
        //	if (bufferedReader != null)
        //	{
        //		try 
        //		{
        //			bufferedReader.close();
        //		} 
        //		catch (IOException e) 
        //		{
        //			e.printStackTrace();
        //		}
        //	}
        //}
	}
}

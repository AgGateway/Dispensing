# Mix Ticket: Dispensing Work Order and Work Record
Historically, customers of Process Control System software vendors would dictate a variety of custom formats and integration methods which would make implementation and support extremely challenging for both the customer and the process control system software vendor.  The AgGateway MixTicket Work Group has created work order and work record standards that lower the cost of implementation, and aid the addition of new facilities and standardized capabilities.

The scope of this resource to exchange work orders for blending/dispensing operations to create a finished good product, and to report the work order completions in the form of work records.  The work record communicates the actual ingredient and amounts consumed for the manufacturing operation. 

Logistical aspects may also be included with the work record to indicate specific carrier used to ship the product and attach a copy of the Bill of Lading provided to the carrier.  

Examples:

One or more ProcessControlSystem(s) can call the GET /facility/{facilityID}/dispensingWorkorders API which retrieves new, updated, or cancelled work orders from the ERP.  This approach provides a single URI endpoint and credentials to configure in the ProcessControlSystem(s).  The only parameters in the resource path is the facilityID and the only query parameter is the lastExecutionDateTime.  This means that the ERP would need to be able to serve up all new, updated or cancelled work orders since the last time the API was called by the ProcessControlSystem.

The ERP responds with the JSON payload conforming to the dispensingWorkOrder JSON Schema that has been created by AgGateway MixTicket Work Group.  PLEASE NOTE: if the ERP returns a large number of work orders, it is recommended to increase the frequency of the invocation of the API.

The ProcessControlSystem at that facility will parse the JSON, and insert NEW work orders into its local database.  The behavior of the UPDATE and CANCEL work orders is ProcessControlSystem specific and left to the implementer.  The typical behavior is to check to see if the work order is in-progress before an UPDATE or CANCEL is performed.  

![image](https://user-images.githubusercontent.com/69859591/211103962-81d2f984-0cf3-408c-9c27-14c740d3f32e.png)


Another option discussed is a 'push' method, where the ERP is using HTTP  POST to the process control system.  This works well with cloud based solutions.

![image](https://user-images.githubusercontent.com/69859591/211104073-5197733a-336a-4fa0-a5c2-5d464afe5732.png)

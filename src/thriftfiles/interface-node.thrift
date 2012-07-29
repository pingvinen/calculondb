
include "shared.thrift"


namespace csharp CalculonDb


/**
 * The service implemented by the Interface nodes
 */
service InterfaceNodeService {

	/**
	 * Insert an entry into the stream
	 */
	shared.Result insert(1: shared.Entry entry)
	
	/**
	 * Get the state of the report with the
	 * given report name
	 */
	shared.Result get(1: string reportName)
	
	/**
	 * Get the state of all the reports 
	 * belonging to the given set
	 */
	shared.Result getList(1: string setName)
}

include "shared.thrift"


namespace csharp CalculonDb


/**
 * The service implemented by the Interface nodes
 */
service InterfaceNodeService {

	/**
	 * Insert an entry into the stream
	 */
	shared.Result Insert(1: shared.Entry entry)
	
	/**
	 * Get the state of the report with the
	 * given report name
	 */
	shared.Result GetReport(1: string reportName)
	
	/**
	 * Get the state of all the reports 
	 * belonging to the given set
	 */
	shared.Result GetSet(1: string setName)
}

include "shared.thrift"


namespace csharp CalculonDb


/**
 * The service implemented by the Report nodes
 */
service ReportNodeService {

	/**
	 * Tell the report node to aggregate
	 * reports with the given Entry
	 */
	void Aggregate(1: shared.Entry entry)
}
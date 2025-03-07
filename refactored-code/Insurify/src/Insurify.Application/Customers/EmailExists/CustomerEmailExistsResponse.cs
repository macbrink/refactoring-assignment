namespace Insurify.Application.Customers.EmailExists
{
    /// <summary>
    /// Response model for the customer email exists
    /// </summary>
	public sealed class CustomerEmailExistsResponse
	{
        /// <summary>
        /// Gets or Sets email address exists
        /// </summary>
        public bool Exists { get; set; }
    }
}

<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="TimelessTreasuresWeb1.ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Shop Page</h1>
					<nav class="d-flex align-items-center">
						<a href="Home.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="Shop.aspx">Shop</a>
						
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->

<!-- Button to trigger the modal -->
<div class="hover-text" style="width: 1100px; margin: 0 auto; padding-top: 50px; padding-bottom: 0px;">
    <asp:Button ID="btnBrowseCategories" CssClass="hover-text" runat="server" Text="Add Product" 
        style="width: 100%; background-color: #3f88c5; color: white; padding: 10px; border: none; cursor: pointer; text-align: center; font-size: 16px;" 
        OnClientClick="$('#addProductModal').modal('show'); return false;" />
</div>

<!-- Modal Structure -->
<div id="addProductModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addProductModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addProductModalLabel">Add Product</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <!-- ASP.NET File Upload and Form Fields -->
                <asp:Panel ID="ProductPanel" runat="server">
                    <div class="form-group">
                        <label for="productTitle">Title:</label>
                        <asp:TextBox ID="productTitle" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="productPrice">Price:</label>
                        <asp:TextBox ID="productPrice" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="productDescription">Description:</label>
                        <asp:TextBox ID="productDescription" runat="server" CssClass="form-control" TextMode="MultiLine" />
                    </div>
                    <div class="form-group">
                        <br />
    <label for="productCategory">Category:</label>
    <asp:DropDownList ID="productCategory" runat="server" CssClass="form-control">
        <asp:ListItem Text="Jewellery" Value="Jewellery"></asp:ListItem>
        <asp:ListItem Text="Stationery" Value="Stationery"></asp:ListItem>
        <asp:ListItem Text="Art Supplies" Value="Art Supplies"></asp:ListItem>
        <asp:ListItem Text="Kitchen & Dining" Value="Kitchen & Dining"></asp:ListItem>
        <asp:ListItem Text="Clothing" Value="Clothing"></asp:ListItem>
        <asp:ListItem Text="Mugs" Value="Mugs"></asp:ListItem>
        <asp:ListItem Text="Travel Accessories" Value="Travel Accessories"></asp:ListItem>
        <asp:ListItem Text="Greeting Cards" Value="Greeting Cards"></asp:ListItem>
        <asp:ListItem Text="Musical Instruments" Value="Musical Instruments"></asp:ListItem>
        <asp:ListItem Text="Bags" Value="Bags"></asp:ListItem>
        <asp:ListItem Text="Accessories" Value="Accessories"></asp:ListItem>
    </asp:DropDownList>
</div>
					<br />
                    <div class="form-group">
                        <label for="productImageUpload">Upload Image:</label>
                        <asp:FileUpload ID="productImageUpload" runat="server" CssClass="form-control-file" accept="image/*" />
                    </div>
                    <div class="form-group">
                        <label for="productQuantity">Quantity:</label>
                        <asp:TextBox ID="productQuantity" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="productVisible">Visible (1 for Yes, 0 for No):</label>
                        <asp:TextBox ID="productVisible" runat="server" CssClass="form-control" />
                    </div>
                </asp:Panel>
            </div>
            <div class="modal-footer">
                <button type="button" style="background-color:#3f88c5;" data-dismiss="modal">Close</button>
                <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" style="background-color:#fd7e14;" OnClick="AddProduct_Click" />
            </div>
        </div>
    </div>
</div>

	<!-- Success/Error Modal Structure -->
<div id="messageModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="messageModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content" style="background-color: #ffba00;">
            <div class="modal-header" style="background-color: #ffba00; border-bottom: none;">
                <h5 class="modal-title" id="messageModalLabel" style="color: white;">Message</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color: white;">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body" id="messageModalBody" style="background-color: #ffba00; color: white;">
                <!-- Message content will be injected here -->
            </div>
            <div class="modal-footer" style="background-color: #ffba00; border-top: none;">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>


	<script type="text/javascript">
    function showMessageModal(message) {
        var sanitizedMessage = message.replace(/'/g, "\\'");
        document.getElementById('messageModalBody').innerText = sanitizedMessage;
        $('#messageModal').modal('show');
    }
</script>

<!-- Edit Product Modal Structure -->
<div id="editProductModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="editProductModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="editProductModalLabel">Edit Product</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <!-- Hidden field to store the existing image URL -->
                <input type="hidden" id="existingImageUrl" />

                <!-- Standard HTML fields for product details -->
                <input type="hidden" id="hiddenProductId" />
                <div class="form-group">
                    <label for="editProductTitle">Title:</label>
                    <input type="text" id="editProductTitle" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="editProductPrice">Price:</label>
                    <input type="text" id="editProductPrice" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="editProductDescription">Description:</label>
                    <textarea id="editProductDescription" class="form-control"></textarea>
                </div>
               
                <div class="form-group">
                    <label for="editProductCategory">Category:</label>
                    <select id="editProductCategory" class="form-control">
                        <option value="Jewellery">Jewellery</option>
<option value="Stationery">Stationery</option>
<option value="Art Supplies">Art Supplies</option>
<option value="Kitchen & Dining">Kitchen & Dining</option>
<option value="Clothing">Clothing</option>
<option value="Mugs">Mugs</option>
<option value="Travel Accessories">Travel Accessories</option>
<option value="Greeting Cards">Greeting Cards</option>
<option value="Musical Instruments">Musical Instruments</option>
<option value="Bags">Bags</option>
<option value="Accessories">Accessories</option>
                        
                    </select>
                </div>
                 <br />
                <div class="form-group">
                    <label for="editProductImageUpload">Image:</label>
                    <input type="file" id="editProductImageUpload" class="form-control-file" />
                </div>
                <div class="form-group">
                    <label for="editProductQuantity">Quantity:</label>
                    <input type="text" id="editProductQuantity" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="editProductVisible">Visible (1 for Yes, 0 for No):</label>
                    <input type="text" id="editProductVisible" class="form-control" />
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" style="background-color:#3f88c5;" data-dismiss="modal">Close</button>
                <button type="button" style="background-color:#fd7e14;" onclick="saveProductChanges()">Save Changes</button>
            </div>
        </div>
    </div>
</div>



<script type="text/javascript">
        function openEditModal(productId) {
            $.ajax({
                type: "POST", // Use POST for WebMethod calls
                url: "ManageProducts.aspx/GetProductDetails", // URL to your WebMethod
                contentType: "application/json; charset=utf-8", // Required content type for WebMethod calls
                dataType: "json", // Expect JSON response from the server
                data: JSON.stringify({ id: productId }), // Data to be sent to the server in JSON format
                success: function (data) {
                    $('#hiddenProductId').val(data.d.id);
                    $('#editProductTitle').val(data.d.title);
                    $('#editProductPrice').val(data.d.price);
                    $('#editProductDescription').val(data.d.description);
                    $('#editProductCategory').val(data.d.category);
                    $('#editProductQuantity').val(data.d.quantity);
                    $('#editProductVisible').val(data.d.visible);

                    // Store the existing image URL in a hidden field
                    $('#existingImageUrl').val(data.d.imageUrl);

                    // Open the modal after populating it with the data
                    $('#editProductModal').modal('show');
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error: ", status, error);
                    console.error("Response Text: ", xhr.responseText);
                    alert('Failed to fetch product details.');
                }
            });
        }



</script>



<script type="text/javascript">

        function saveProductChanges() {
            const productId = parseInt($('#hiddenProductId').val(), 10);
            const title = $('#editProductTitle').val();
            const price = parseFloat($('#editProductPrice').val()); // Convert to decimal/float
            const description = $('#editProductDescription').val();
            const category = $('#editProductCategory').val();
            const quantity = parseInt($('#editProductQuantity').val(), 10); // Convert to integer
            const visible = parseInt($('#editProductVisible').val(), 10); // Convert to integer

            // Check if a new image has been uploaded; if not, use the existing image URL
            const image = $('#editProductImageUpload').val() ? $('#editProductImageUpload').val() : $('#existingImageUrl').val();

            // Make an AJAX request to save the changes
            $.ajax({
                type: "POST",
                url: "ManageProducts.aspx/SaveProductChanges", // Updated to match the page and WebMethod name
                contentType: "application/json; charset=utf-8", // Required for WebMethod calls
                dataType: "json", // Expecting JSON response from the server
                data: JSON.stringify({
                    id: productId,
                    title: title,
                    price: price,
                    description: description,
                    category: category,
                    image: image, // Pass the correct image URL
                    quantity: quantity,
                    visible: visible
                }),
                success: function (response) {
                    console.log('Server response:', response); // Debugging line to check the server's response
                    alert('Product changes saved successfully!');
                    $('#editProductModal').modal('hide');
                    // Optionally refresh the product list if necessary
                },
                error: function (xhr, status, error) {
                    console.error("Error saving product changes: ", status, error);
                    console.error("Response Text:", xhr.responseText); // Debugging line for error details
                    alert('Error saving product changes.');
                }
            });
        }



</script>

    <!-- Delete Confirmation Modal -->
<div id="deleteConfirmationModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="deleteConfirmationModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="deleteConfirmationModalLabel">Delete Product</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <p>Are you sure you want to delete the following product?</p>
                <p><strong>Product Name:</strong> <span id="deleteProductName"></span></p>
                <p><strong>Price:</strong> <span id="deleteProductPrice"></span></p>
                <!-- Add other product details as needed -->
            </div>
            <div class="modal-footer">
                <button type="button" style="background-color:#3f88c5;" data-dismiss="modal">No</button>
                <button type="button" style="background-color:#fd7e14;" id="confirmDeleteButton">Yes, Delete</button>
            </div>
        </div>
    </div>
</div>



<script type="text/javascript">
    $(document).ready(function () {
        // Attach the click event to the delete button inside the modal
        $('#confirmDeleteButton').on('click', function () {
            const productId = $(this).data('product-id');
            deleteProduct(productId); // Call the deleteProduct function with the product ID
        });
    });

    // Function to open the delete confirmation modal
    function openDeleteConfirmationModal(productId, productName, productPrice) {
        // Populate the modal with the product details
        $('#deleteProductName').text(productName);
        $('#deleteProductPrice').text(productPrice);

        // Store the product ID in the delete button's data attribute for later use
        $('#confirmDeleteButton').data('product-id', productId);

        // Show the delete confirmation modal
        $('#deleteConfirmationModal').modal('show');
    }

    // Function to make the AJAX request to delete the product
    function deleteProduct(productId) {
        $.ajax({
            type: "POST",
            url: "ManageProducts.aspx/DeleteProduct", // Ensure this URL matches your WebMethod's location
            contentType: "application/json; charset=utf-8", // Required content type for WebMethod calls
            dataType: "json", // Expecting JSON response from the server
            data: JSON.stringify({ id: productId }), // Send the product ID to the server
            success: function (response) {
                if (response.d === "Success") {
                    alert('Product deleted successfully!');
                    $('#deleteConfirmationModal').modal('hide');
                    // Optionally refresh the product list here
                } else {
                    alert('Error: ' + response.d);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error deleting product: ", status, error);
                alert('Error deleting product.');
            }
        });
    }
</script>


    

   








	<div class="container" style="margin-top: 50px;" >
		<div class="row">
			<div class="col-xl-3 col-lg-4 col-md-5">
				<div class="sidebar-categories">
					<div class="head" style="background-color:#3f88c5;">Browse Categories</div>
					<ul class="main-categories">
	<li class="main-nav-list"><asp:LinkButton ID="AllLink" runat="server" CommandArgument="All" OnClick="Category_Click">All<span class="number">(32)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="JewelleryLink" runat="server" CommandArgument="Jewellery" OnClick="Category_Click">Jewellery<span class="number">(3)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="StationeryLink" runat="server" CommandArgument="Stationery" OnClick="Category_Click">Stationery<span class="number">(3)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="ArtSuppliesLink" runat="server" CommandArgument="Art Supplies" OnClick="Category_Click">Art Supplies<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="KitchenDiningLink" runat="server" CommandArgument="Kitchen & Dining" OnClick="Category_Click">Kitchen & Dining<span class="number">(3)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="ClothingLink" runat="server" CommandArgument="Clothing" OnClick="Category_Click">Clothing<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="HomeDecorLink" runat="server" CommandArgument="Mugs" OnClick="Category_Click">Mugs<span class="number">(6)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="TravelAccessoriesLink" runat="server" CommandArgument="Travel Accessories" OnClick="Category_Click">Travel Accessories<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="GreetingCardsLink" runat="server" CommandArgument="Greeting Cards" OnClick="Category_Click">Greeting Cards<span class="number">(5)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="MusicalInstrumentsLink" runat="server" CommandArgument="Musical Instruments" OnClick="Category_Click">Musical Instruments<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="BagsLink" runat="server" CommandArgument="Bags" OnClick="Category_Click">Bags<span class="number">(6)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="AccessoriesLink" runat="server" CommandArgument="Accessories" OnClick="Category_Click">Accessories<span class="number">(2)</span></asp:LinkButton></li>
</ul>

				</div>
				<div class="sidebar-filter mt-50">
					
					
					
				</div>
			</div>
			<div class="col-xl-9 col-lg-8 col-md-7">
				<!-- Start Filter Bar -->
				<div class="filter-bar d-flex flex-wrap align-items-center" style="background-color:#3f88c5;">
					<div class="sorting" >

						<asp:DropDownList ID="SortList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SortList_SelectedIndexChanged">

						  <asp:ListItem Value="0">Default sorting</asp:ListItem>
						  <asp:ListItem Value="1">Price:High to low</asp:ListItem>
						  <asp:ListItem Value="2">Price:Low to High</asp:ListItem>
						  <asp:ListItem Value="3">Alphabet:A-Z</asp:ListItem>
						  <asp:ListItem Value="4">Alphabet:Z-A</asp:ListItem>
						</asp:DropDownList>
					
					</div>
					<!-- Not Going to do anything here -->
					<div class="sorting mr-auto">
						<asp:DropDownList ID="ItemsPerPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemsPerPage_SelectedIndexChanged">
							<asp:ListItem Value="6">Show 6</asp:ListItem>
							<asp:ListItem Value="12">Show 12</asp:ListItem>
							<asp:ListItem Value="24">Show 24</asp:ListItem>
							<asp:ListItem Value="32">Show All</asp:ListItem>
						</asp:DropDownList>
					</div>

					<div class="pagination">

						<asp:LinkButton ID="PrevPageButton" runat="server" CommandName="Prev" OnClick="PageNavigation_Click" CssClass="prev-arrow">
							<i class="fa fa-long-arrow-left" aria-hidden="true"></i>
						</asp:LinkButton>

						<asp:LinkButton ID="Page1" runat="server" CommandArgument="1" OnClick="PageNavigation_Click" CssClass="active">1</asp:LinkButton>
						<asp:LinkButton ID="Page2" runat="server" CommandArgument="2" OnClick="PageNavigation_Click">2</asp:LinkButton>
						<asp:LinkButton ID="Page3" runat="server" CommandArgument="3" OnClick="PageNavigation_Click">3</asp:LinkButton>
						<asp:LinkButton ID="Page4" runat="server" CommandArgument="4" OnClick="PageNavigation_Click">4</asp:LinkButton>
						<asp:LinkButton ID="Page5" runat="server" CommandArgument="5" OnClick="PageNavigation_Click">5</asp:LinkButton>



						<asp:LinkButton ID="NextPageButton" runat="server" CommandName="Next" OnClick="PageNavigation_Click" CssClass="next-arrow">
							<i class="fa fa-long-arrow-right" aria-hidden="true"></i>
						</asp:LinkButton>
	
					</div>

				</div>
				<!-- End Filter Bar -->
				<!-- Start Best Seller -->
				<section class="lattest-product-area pb-40 category-list">
					<div class="row">
					<asp:Literal ID="Product" runat="server"></asp:Literal>
				
					</div>
				</section>
				<!-- End Best Seller -->
<!-- Start Filter Bar -->
				<div class="filter-bar d-flex flex-wrap align-items-center" style="background-color:#3f88c5;">
					<div class="sorting" >

						<asp:DropDownList ID="SortList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SortList_SelectedIndexChanged">

						  <asp:ListItem Value="0">Default sorting</asp:ListItem>
						  <asp:ListItem Value="1">Price:High to low</asp:ListItem>
						  <asp:ListItem Value="2">Price:Low to High</asp:ListItem>
						  <asp:ListItem Value="3">Alphabet:A-Z</asp:ListItem>
						  <asp:ListItem Value="4">Alphabet:Z-A</asp:ListItem>
						</asp:DropDownList>
					
					</div>
					<!-- Not Going to do anything here -->
					<div class="sorting mr-auto">
						<asp:DropDownList ID="ItemsPerPage2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemsPerPage_SelectedIndexChanged">
							<asp:ListItem Value="6">Show 6</asp:ListItem>
							<asp:ListItem Value="12">Show 12</asp:ListItem>
							<asp:ListItem Value="24">Show 24</asp:ListItem>
							<asp:ListItem Value="32">Show All</asp:ListItem>
						</asp:DropDownList>
					</div>

					<div class="pagination">

						<asp:LinkButton ID="PrevPageButton2" runat="server" CommandName="Prev" OnClick="PageNavigation_Click" CssClass="prev-arrow">
							<i class="fa fa-long-arrow-left" aria-hidden="true"></i>
						</asp:LinkButton>

						<asp:LinkButton ID="Page12" runat="server" CommandArgument="1" OnClick="PageNavigation_Click" CssClass="active">1</asp:LinkButton>
						<asp:LinkButton ID="Page22" runat="server" CommandArgument="2" OnClick="PageNavigation_Click">2</asp:LinkButton>
						<asp:LinkButton ID="Page32" runat="server" CommandArgument="3" OnClick="PageNavigation_Click">3</asp:LinkButton>
						<asp:LinkButton ID="Page42" runat="server" CommandArgument="4" OnClick="PageNavigation_Click">4</asp:LinkButton>
						<asp:LinkButton ID="Page52" runat="server" CommandArgument="5" OnClick="PageNavigation_Click">5</asp:LinkButton>



						<asp:LinkButton ID="NextPageButton2" runat="server" CommandName="Next" OnClick="PageNavigation_Click" CssClass="next-arrow">
							<i class="fa fa-long-arrow-right" aria-hidden="true"></i>
						</asp:LinkButton>
	
					</div>

				</div>
				<!-- End Filter Bar -->
			</div>
		</div>
	</div>
</asp:Content>

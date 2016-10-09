<?php include ('layouts/header.php'); ?>

    <!-- Javascript example, 3D Printing Layer Calculator -->
    <center><h1>3D Printing Layer Calculator</h1></center>
    <br />
    <!-- Div for whole calculator -->
    <div id="calc" class="row">
        <div class="col-md-12">
           <!-- Form for user input to determine calculation -->
            <form id="calcLayers" class="form-inline">
               <!-- Printer options selector -->
                <div id="printer-selector" class="form-group">
                    <label for="printers">3D Printer: </label>
                    <select name="printer-select" id="printers" class="form-control">
                        <option value="choose">Please select a printer </option>
                        <option value="cube">CubePro</option>
                        <option value="makerbot">Makerbot Replicator 2</option>
                        <option value="ultimaker">Ultimaker 2</option>
                        <option value="unknown">Unknown</option>
                    </select>
                </div>
                <!-- Object height input -->
                <div id="height-input" class="form-group">
                    <label for="height">Object Height: </label>
                    <input type="text" class="form-control" id="height" maxlength="5" placeholder="Enter desired height" />
                    <span class="glyphicon glyphicon-remove form-control-feedback hidden"></span>
                </div>
                <!-- Unit selection -->
                <div class="form-group radio">
                    <label for="radio-unit" class="radio-inline">
                        <input type="radio" name="radio-unit" value="in" checked/>in
                    </label>
                    <label for="radio-unit" class="radio-inline">
                        <input type="radio" name="radio-unit" value="cm" />cm
                    </label>
                </div>
                <!-- Calculation button -->
                <div class="form-group">
                    <button type="submit" class="btn btn-primary">Calculate</button>
                </div>
            </form>
            <!-- Span for error text for incorrect input -->
            <span class="help-block hidden">Error text goes here</span>
        </div>
        <div id="calcResults">
            <!-- Javascript will put results here -->
        </div>
    </div> <!-- End calc div -->

<?php include ('layouts/footer.php'); ?>
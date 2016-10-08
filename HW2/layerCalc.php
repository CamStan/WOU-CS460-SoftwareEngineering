<?php include ('layouts/header.php'); ?>


    <center>
        <h1>3D Printing Layer Calculator</h1>
    </center>
    <br />
    <div id="calc" class="row">
        <div class="col-md-12">
            <form id="calcLayers" class="form-inline">
                <div id="printer-selector" class="form-group">
                    <label for="printers">3D Printer: </label>
                    <select name="printer-select" id="printers" class="form-control">
                        <option value="choose">Please select a printer </option>
                        <option value="cube">Cube Pro</option>
                        <option value="makerbot">Makerbot</option>
                        <option value="ultimaker">Ultimaker</option>
                        <option value="unknown">Unknown</option>
                    </select>
                </div>
                <div id="height-input" class="form-group">
                    <label for="height">Object Height: </label>
                    <input type="text" class="form-control" id="height" maxlength="5" placeholder="Enter desired height" />
                    <span class="glyphicon glyphicon-remove form-control-feedback hidden"></span>
                </div>
                <div class="form-group radio">
                    <label for="radio-unit" class="radio-inline">
                        <input type="radio" name="radio-unit" value="inches" checked/>in
                    </label>
                    <label for="radio-unit" class="radio-inline">
                        <input type="radio" name="radio-unit" value="centimeters" />cm
                    </label>
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-primary">Calculate</button>
                </div>
            </form>
            <span class="help-block hidden">Error text goes here</span>
        </div>
        <div id="calcResults">
            <!--            Javascript will put results here-->
        </div>
    </div>

    <?php include ('layouts/footer.php'); ?>